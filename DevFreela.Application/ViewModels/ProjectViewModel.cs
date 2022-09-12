using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string title, DateTime createdAt)
        {
            this.Title = title;
            this.CreatedAt = createdAt;
        }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}