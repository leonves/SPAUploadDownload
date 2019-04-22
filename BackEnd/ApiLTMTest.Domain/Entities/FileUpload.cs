using System;
using System.ComponentModel.DataAnnotations;

namespace ApiLTMTest.Domain.Entities
{
    public class FileUpload : EntityBase<int>
    {

        [Required]
        public string FileName { get; set; }

        public long FileSize { get; set; }

        public string FilePath { get; set; }

        public string OwnerFile { get; set; }
        
        public DateTime FileLastAcess { get; set; }
    }
}
