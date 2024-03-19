using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Dto
{
    public record commentDtoUpload(
               Guid guid,
               string Text,
               DateTime Date
        );
}
