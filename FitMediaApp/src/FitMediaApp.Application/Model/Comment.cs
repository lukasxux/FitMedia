using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Model
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;
    using FitMediaApp.Application.Model;

    public class Comment : IEntity<int>
    {
        public Comment(User user, string text, DateTime date) { 
            User = user;
            Text = text;
            Date = date;
        }


#pragma warning disable CS8618
        protected Comment() { }
#pragma warning restore CS8618

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public User User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
