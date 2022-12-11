using DockerExample.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerExample.Domain.Entities
{
  public class Book : BaseEntity
  {
    public string Name { get; set; }
    public int Page { get; set; }
  }
}
