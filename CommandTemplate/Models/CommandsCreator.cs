using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandTemplate.Models;
using System.Configuration;

namespace CommandTemplate.Models
{
    public static class CommandsCreator
    {
        public static List<Command> Execute()
        {
            var appSettingsReader = new AppSettingsReader();
            string templateDocPath = (string)appSettingsReader.GetValue("TemplateDocPath", typeof(string));
            string dataDocPath = (string)appSettingsReader.GetValue("DataDocPath", typeof(string));
            string outputDocsFolder = (string)appSettingsReader.GetValue("OutputDocsFolder", typeof(string));

            var commands = new List<Command>();

            var transmittalLetterCreator = new TransmittalLetterCreator(templateDocPath, dataDocPath, outputDocsFolder);
            Command transmittalLetterCreate = new TransmittalLetterCreate(transmittalLetterCreator);
            transmittalLetterCreate.Name = "Сопроводительные письма";
            transmittalLetterCreate.SysName = "TransmittalLetters";

            commands.Add(transmittalLetterCreate);


            return commands;
        }
    }
}
