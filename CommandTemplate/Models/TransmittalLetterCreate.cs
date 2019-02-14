using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTemplate.Models
{
    class TransmittalLetterCreate : Command
    {
        private Combinator transmittalLetterCreator;

        public TransmittalLetterCreate(Combinator transmittalLetterCreator)
        {
            this.transmittalLetterCreator = transmittalLetterCreator;
        }

        public async override Task ExecuteAsync()
        {
            await Task.Run(() =>
            {
                transmittalLetterCreator.Combine();
            });
            
        }
    }
}