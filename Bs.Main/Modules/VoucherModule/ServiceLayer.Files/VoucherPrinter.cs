using Bs.Main.Modules.VoucherModule.Entities;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Humanizer.NumberToWordsExtension;

namespace Bs.Main.Modules.VoucherModule.ServiceLayer.Files
{
    public class VoucherPrinter
    {
        public void Print(Voucher voucher)
        {
            string templatePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\Templates\voucher template.xls";
            string voucherDirectory = $@"\vouchers\";
            Directory.CreateDirectory(voucherDirectory);
            string newVoucherName = voucherDirectory + DateTime.Now.ToString("yyyyMMddHHmm") + ".xls";
            File.Copy(templatePath, newVoucherName, true);

            var book = new HSSFWorkbook();

            using (var fs = new FileStream(newVoucherName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                book = new HSSFWorkbook(fs);
            }

            HSSFSheet sheet = (HSSFSheet)book.GetSheetAt(0);

            string parsumm = $"Representing Payment for: {string.Join(", ", voucher.JournalEntries.Select(j => j.JournalAccountName).ToArray())}";


            foreach (int partAdjustment in new[] { 0, 38 })
            {
                sheet.GetRow(0 + partAdjustment).Cells[0].SetCellValue(voucher.Company.Name);

                sheet.GetRow(2 + partAdjustment).Cells[1].SetCellValue($"** {voucher.PayeeNameToUse} **");
                sheet.GetRow(3 + partAdjustment).Cells[8].SetCellValue(voucher.VoucherNumber);
                sheet.GetRow(4 + partAdjustment).Cells[1].SetCellValue(voucher.EntryDate.ToString("MMM dd, yyyy"));

                int particularsIndex = 6;
                int chartOfAccountsIndex = 24;

                sheet.GetRow(Append(ref particularsIndex) + partAdjustment).Cells[1].SetCellValue(parsumm);

                foreach (var d in voucher.JournalEntries)
                {
                    Append(ref particularsIndex);

                    // PARTICULARS
                    IRow journalLineRow = sheet.GetRow(Append(ref particularsIndex) + partAdjustment);
                    journalLineRow.Cells[1].SetCellValue(d.JournalAccountName);
                    journalLineRow.Cells[9].SetCellValue("PHP");
                    journalLineRow.Cells[10].SetCellValue(d.Amount);


                    // CHART OF ACCOUNTS
                    IRow coaRow = sheet.GetRow(Append(ref chartOfAccountsIndex) + partAdjustment);
                    coaRow.Cells[0].SetCellValue(d.JournalAccountName);
                    coaRow.Cells[4].SetCellValue(voucher.GrossAmount);

                    //if (d.TaxAmount > 0d)
                    //{
                    // PARTICULARS
                    IRow particularsWtaxRow = sheet.GetRow(Append(ref particularsIndex) + partAdjustment);
                    particularsWtaxRow.Cells[7].SetCellValue($"less {d.WithholdingTaxRate * 100}% wtax");
                    particularsWtaxRow.Cells[10].SetCellValue(d.TaxAmount);


                    // CHART OF ACCOUNTS
                    IRow coaWtaxRow = sheet.GetRow(Append(ref chartOfAccountsIndex) + partAdjustment);
                    coaWtaxRow.Cells[0].SetCellValue("        wtax");
                    coaWtaxRow.Cells[5].SetCellValue(Math.Abs(d.TaxAmount));
                    //}

                    // PARTICULARS
                    if (partAdjustment > 0)
                        foreach (var p in d.Particulars)
                            sheet.GetRow(Append(ref particularsIndex) + partAdjustment).Cells[1].SetCellValue($"{p.Key}:  {p.Value}");


                }

                IRow grandTotalRow = sheet.GetRow(20 + partAdjustment);
                grandTotalRow.Cells[9].SetCellValue("PHP");
                grandTotalRow.Cells[10].SetCellValue(voucher.NetAmount);

                Append(ref chartOfAccountsIndex);
                IRow coaTotalRow = sheet.GetRow(Append(ref chartOfAccountsIndex) + partAdjustment);
                coaTotalRow.Cells[0].SetCellValue($"        Cash in Bank({voucher.CompanyAccountCode})");
                coaTotalRow.Cells[5].SetCellValue(voucher.NetAmount);

                sheet.GetRow(24 + partAdjustment).Cells[7].SetCellValue(voucher.GrossAmount.ToWords());

                sheet.GetRow(28 + partAdjustment).Cells[7].SetCellValue(voucher.CompanyAccountCode);
                sheet.GetRow(28 + partAdjustment).Cells[9].SetCellValue(voucher.VoucherNumber);

                sheet.GetRow(31 + partAdjustment).Cells[6].SetCellValue(""); // .Received_By)

                sheet.GetRow(34 + partAdjustment).Cells[0].SetCellValue(""); // .Prepared_By_Fullname)
                sheet.GetRow(34 + partAdjustment).Cells[3].SetCellValue(""); // .Certified_By_Fullname)
                sheet.GetRow(34 + partAdjustment).Cells[6].SetCellValue(""); // .Approved_By_Fullname)
            }

            using (var fs = new FileStream(newVoucherName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                book.Write(fs);
            }

            book.Close();

            Process oProcess = new();
            oProcess.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = true,
                Verb = "Print",
                FileName = newVoucherName
            };
            oProcess.Start();
        }

        private static int Append(ref int index)
        {
            index++;
            return index;
        }

    }
    internal static class exten
    {
        public static string ToWords(this double value)
        {
            if (value > 0)
            {
                string stringValue;
                string[] valueArgs = value.ToString("0.00").Split(".");
                stringValue = int.Parse(valueArgs[0]).ToWords();
                if (valueArgs.Length > 1)//cents
                    stringValue = $"{stringValue} & {valueArgs[1]}/100 ONLY";
                return stringValue.ToUpper();
            }
            return string.Empty;
        }
    }
}
