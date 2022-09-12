using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Dao              
{
    static class Repository
    {
        private const string ContainerName = "blobcontainer";
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString; //ne moze biti const jer se const evaluira u compile time-u, a desni dio je u run time-u

        private static readonly Lazy<BlobContainerClient> containter = new Lazy<BlobContainerClient>(() => new BlobServiceClient(cs).GetBlobContainerClient(ContainerName));
        public static BlobContainerClient Container => containter.Value;
    }
}
