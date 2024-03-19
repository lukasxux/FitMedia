﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Dto
{
        public record CommentDto(
               UserDtoForComment User,
               string Text,
               DateTime Date
           );
}
