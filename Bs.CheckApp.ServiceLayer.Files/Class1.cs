using System;

namespace Bs.CheckApp.ServiceLayer.Files
{
    public class Class1
    {
        //private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    var font = new Font("Arial", 11f);

        //    // e.PageSettings.Landscape = True
        //    dDate = Conversions.ToDate(this.dtpDate.Text);

        //    int yadjuster = (int)Math.Round(-("0" + this.tbYAxisAdjustment.Text));
        //    int xadjuster = Conversions.ToInteger("0" + this.tbXAxisAdjustment.Text);

        //    CheckGenerator.CodeInf code = (CheckGenerator.CodeInf)this.cmbCodes.SelectedItem;

        //    if (printEndrs == true) // IF ENDORSEMENT
        //    {
        //        font = new Font("Arial", 9f);
        //        e.PageSettings.Landscape = true;
        //        e.Graphics.DrawString(this.txtEndorse.Text, font, Brushes.Black, (float)(20 + xadjuster), 20f);
        //    }
        //    else
        //    {
        //        int spaceWidth = 700;
        //        e.PageSettings.Landscape = true;
        //        e.PageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
        //        dDate = Conversions.ToDate(this.dtpDate.Text);

        //        string payee1 = this.txtpay1.Text.Trim();
        //        string payee2 = this.txtpay2.Text.Trim();
        //        string amount = "**" + Strings.FormatCurrency("0" + this.txtAmount.Text.Trim()).Replace("$", "") + "**";

        //        int payee1X = (int)Math.Round((double)(spaceWidth - CheckGenerator.BackProcess.getStrWidth(payee1.ToUpper(), font, e)) / 2d);
        //        int payee2X = (int)Math.Round((double)(spaceWidth - CheckGenerator.BackProcess.getStrWidth(payee2, font, e)) / 2d);

        //        if (amount.Length > 0)
        //        {
        //            string[] cents = null;
        //            if (amount.Contains("."))
        //            {
        //                cents = amount.Split('.');
        //            }
        //            if (Conversion.Val(amount) > 0d)
        //            {
        //                this.txtInword.Text = " **" + CheckGenerator.mdlNumtoWord.AmountInWords(amount) + " & " + cents[1] + "/100 ONLY**";
        //            }
        //        }
        //        else
        //        {
        //            this.txtInword.Text = "";
        //        }


        //        if (code.CheckType == 1)
        //        {
        //            if (this.chkbDate.Checked)
        //            {
        //                e.Graphics.DrawString(Strings.Format(Conversions.ToDate(dDate), "MMMM dd, yyyy"), font, Brushes.Black, 570f, 590 + yadjuster);
        //            }
        //            if (payee2.Length > 0)
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 605 + yadjuster);
        //                e.Graphics.DrawString(payee2, font, Brushes.Black, payee2X, 620 + yadjuster);
        //            }
        //            else
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 620 + yadjuster);
        //            }
        //            // Amount
        //            if (Conversion.Val(this.txtAmount.Text) > 0d)
        //            {
        //                e.Graphics.DrawString(amount, font, Brushes.Black, 595f, 618 + yadjuster);
        //            }
        //            e.Graphics.DrawString(this.txtInword.Text, font, Brushes.Black, 90f, (float)(645 + yadjuster));
        //        }
        //        else if (code.CheckType == 2) // cmbCodes.SelectedItem = "ULU" Then
        //        {
        //            if (this.chkbDate.Checked)
        //            {
        //                e.Graphics.DrawString(Strings.Format(Conversions.ToDate(dDate), "MMMM dd, yyyy"), font, Brushes.Black, 600f, 590 + yadjuster);
        //            }
        //            if (payee2.Length > 0)
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 605 + yadjuster);
        //                e.Graphics.DrawString(payee2, font, Brushes.Black, payee2X, 620 + yadjuster);
        //            }
        //            else
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 620 + yadjuster);
        //            }
        //            // Amount
        //            if (Conversion.Val(this.txtAmount.Text) > 0d)
        //            {
        //                e.Graphics.DrawString(amount, font, Brushes.Black, 600f, 618 + yadjuster);
        //            }
        //            e.Graphics.DrawString(this.txtInword.Text, font, Brushes.Black, 90f, (float)(645 + yadjuster));
        //        }
        //        else if (code.CheckType == 3) // cmbCodes.SelectedItem = "CTR" Or cmbCodes.SelectedItem = "CSI2" Or cmbCodes.SelectedItem = "DLI" Then
        //        {
        //            if (this.chkbDate.Checked)
        //            {
        //                e.Graphics.DrawString(Strings.Format(Conversions.ToDate(dDate), "MMMM dd, yyyy"), font, Brushes.Black, 550f, 593 + yadjuster);
        //            }
        //            if (payee2.Length > 0)
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 613 + yadjuster);
        //                e.Graphics.DrawString(payee2, font, Brushes.Black, payee2X, 628 + yadjuster);
        //            }
        //            else
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 628 + yadjuster);
        //            }
        //            // Amount
        //            if (Conversion.Val(this.txtAmount.Text) > 0d)
        //            {
        //                e.Graphics.DrawString(amount, font, Brushes.Black, 585f, 630 + yadjuster);
        //            }
        //            e.Graphics.DrawString(this.txtInword.Text, font, Brushes.Black, 90f, (float)(665 + yadjuster));
        //        }
        //        else if (code.CheckType == 4) // cmbCodes.SelectedItem = "CTJ" Then
        //        {
        //            spaceWidth = 500;
        //            font = new Font("Arial", 10f);
        //            payee1X = (int)Math.Round((double)(spaceWidth - CheckGenerator.BackProcess.getStrWidth(payee1.ToUpper(), font, e)) / 2d);
        //            payee2X = (int)Math.Round((double)(spaceWidth - CheckGenerator.BackProcess.getStrWidth(payee2, font, e)) / 2d);
        //            if (this.chkbDate.Checked)
        //            {
        //                e.Graphics.DrawString(Strings.Format(Conversions.ToDate(dDate), "MMMM dd, yyyy"), font, Brushes.Black, 450f, 593 + yadjuster);
        //            }
        //            if (payee2.Length > 0)
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 613 + yadjuster);
        //                e.Graphics.DrawString(payee2, font, Brushes.Black, payee2X, 628 + yadjuster);
        //            }
        //            else
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 628 + yadjuster);
        //            }
        //            // Amount
        //            if (Conversion.Val(this.txtAmount.Text) > 0d)
        //            {
        //                e.Graphics.DrawString(amount, font, Brushes.Black, 500f, 630 + yadjuster);
        //            }
        //            e.Graphics.DrawString(this.txtInword.Text, font, Brushes.Black, 90f, (float)(665 + yadjuster));
        //        }
        //        else if (code.CheckType == 5) // cmbCodes.SelectedItem = "MPF1" Then
        //        {
        //            if (this.chkbDate.Checked)
        //            {
        //                e.Graphics.DrawString(Strings.Format(Conversions.ToDate(dDate), "MMMM dd, yyyy"), font, Brushes.Black, 600f, 590 + yadjuster);
        //            }
        //            if (payee2.Length > 0)
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 605 + yadjuster);
        //                e.Graphics.DrawString(payee2, font, Brushes.Black, payee2X, 620 + yadjuster);
        //            }
        //            else
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 620 + yadjuster);
        //            }
        //            // Amount
        //            if (Conversion.Val(this.txtAmount.Text) > 0d)
        //            {
        //                e.Graphics.DrawString(amount, font, Brushes.Black, 615f, 618 + yadjuster);
        //            }

        //            e.Graphics.DrawString(this.txtInword.Text, font, Brushes.Black, 90f, (float)(645 + yadjuster));
        //        }
        //        else if (code.CheckType == 6) // cmbCodes.SelectedItem = "MTU" Then
        //        {
        //            if (this.chkbDate.Checked)
        //            {
        //                e.Graphics.DrawString(Strings.Format(Conversions.ToDate(dDate), "MMMM dd, yyyy"), font, Brushes.Black, 580f, 585 + yadjuster);
        //            }
        //            if (payee2.Length > 0)
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 595 + yadjuster);
        //                e.Graphics.DrawString(payee2, font, Brushes.Black, payee2X, 615 + yadjuster);
        //            }
        //            else
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 615 + yadjuster);
        //            }
        //            // Amount
        //            if (Conversion.Val(this.txtAmount.Text) > 0d)
        //            {
        //                e.Graphics.DrawString(amount, font, Brushes.Black, 610f, 620 + yadjuster);
        //            }
        //            e.Graphics.DrawString(this.txtInword.Text, font, Brushes.Black, 80f, (float)(648 + yadjuster));
        //        }
        //        else if (code.CheckType == 7) // cmbCodes.SelectedItem = "CSI5" Then
        //        {
        //            if (this.chkbDate.Checked)
        //            {
        //                var datefont = new Font("Arial", 9f);
        //                string month = null;
        //                string day = null;
        //                string year = null;
        //                foreach (char c in dDate.ToString("MM"))
        //                    month += c + "  ";
        //                foreach (char c in dDate.ToString("dd"))
        //                    day += c + "  ";
        //                foreach (char c in dDate.ToString("yyyy"))
        //                    year += c + "  ";
        //                e.Graphics.DrawString(month, datefont, Brushes.Black, 580f, 590 + yadjuster);
        //                e.Graphics.DrawString(day, datefont, Brushes.Black, 630f, 590 + yadjuster);
        //                e.Graphics.DrawString(year, datefont, Brushes.Black, 680f, 590 + yadjuster);
        //            }
        //            if (payee2.Length > 0)
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 605 + yadjuster);
        //                e.Graphics.DrawString(payee2, font, Brushes.Black, payee2X, 620 + yadjuster);
        //            }
        //            else
        //            {
        //                e.Graphics.DrawString(payee1.ToUpper(), font, Brushes.Black, payee1X, 620 + yadjuster);
        //            }
        //            // Amount
        //            if (Conversion.Val(this.txtAmount.Text) > 0d)
        //            {
        //                e.Graphics.DrawString(amount, font, Brushes.Black, 600f, 618 + yadjuster);
        //            }
        //            e.Graphics.DrawString(this.txtInword.Text, font, Brushes.Black, 90f, (float)(645 + yadjuster));
        //        }

        //        if (this.chkbCross.Checked == true)
        //        {
        //            e.Graphics.DrawLine(Pens.Black, 100, 570 + yadjuster, 200, 520 + yadjuster);
        //            e.Graphics.DrawLine(Pens.Black, 115, 570 + yadjuster, 215, 520 + yadjuster);
        //            // e.Graphics.DrawLine(Pens.Black, 300, 500, 600, 500) horizontal
        //        }
        //    }

        //}
    }
}
