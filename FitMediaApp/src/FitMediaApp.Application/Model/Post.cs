﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
    using TeamsDemoApp.Application.Model;

    public class Post : IEntity<int>
    {
        public Post(DateTime date,string filePathPic, string description) { 
            Date =date;
            FilePathPic =filePathPic;
            Description =description;   
        
        }

        #pragma warning disable CS8618
        protected Post() { }
        #pragma warning restore CS8618
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public DateTime Date { get; set; }
        public string FilePathPic { get; set; }
        public string Description { get; set; }
        public List<Comment> Comments { get; } = new();



    }
}