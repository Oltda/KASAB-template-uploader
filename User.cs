using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTemplateUploader
{
    class User
    {
        public string Name { get; set; }
        public ConsumerConfiguration Concf { get; }

        public User(ConsumerConfiguration concf)
        {
            Concf = concf;
        }
    }
}
