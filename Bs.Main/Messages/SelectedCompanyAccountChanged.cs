using Bs.Main.Modules.MasterlistModule.ValueObjects;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Messages
{
    public sealed class SelectedCompanyAccountChanged : ValueChangedMessage<CompanyAccount>
    {
        public SelectedCompanyAccountChanged(CompanyAccount value) : base(value) { }
    }

    public sealed class CurrentCompanyAccount : RequestMessage<CompanyAccount> { }
}
