using Bs.Main.Modules.MasterlistModule.ValueObjects;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Messages
{
    public sealed class JournalAccountCollectionChanged : ValueChangedMessage<IEnumerable<JournalAccount>>
    {
        public JournalAccountCollectionChanged(IEnumerable<JournalAccount> value) : base(value) { }
    }

    public sealed class CurrentJournalAccountCollection : RequestMessage<IEnumerable<JournalAccount>> { }
}
