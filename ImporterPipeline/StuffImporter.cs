using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;

using TImport = System.String;

namespace ImporterPipeline
{
    [ContentImporter(".stuff", DisplayName = "Stuff Importer", DefaultProcessor = "StuffProcessor")]
    public class StuffImporter : ContentImporter<TImport>
    {
        public override string Import(string filename, ContentImporterContext context)
        {
            return System.IO.File.ReadAllText(filename);
        }

    }
}
