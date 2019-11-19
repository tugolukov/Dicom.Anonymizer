using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dicom.Anonymizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceDirectory = @"K:\Source";
            var destinationDirectory = @"K:\Destination";

            var dicomFiles = Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories);
            foreach (var dicomFile in dicomFiles)
            {
                var dicom = DicomFile.Open(dicomFile);
                var anonimize = new DicomAnonymizer();
                anonimize.AnonymizeInPlace(dicom);

                var dataset = dicom.Dataset;
                
                var path = Path.Combine(destinationDirectory, Path.GetFileName(dicomFile));

                dicom.Save(path);
            }
        }
    }
}