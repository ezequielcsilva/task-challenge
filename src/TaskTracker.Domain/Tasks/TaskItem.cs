using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Abstractions;

namespace TaskTracker.Domain.Tasks;

public class TaskItem : Entity
{
    public TaskItem(Guid id, string name, string description, bool isCompleted) : base(id)
    {
        Name = name;
        Description = description;
        IsCompleted = isCompleted;
    }

    private TaskItem()
    { }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool IsCompleted { get; private set; }

    public static TaskItem Create(string name, string description, bool isCompleted)
    {
        return new TaskItem(Guid.NewGuid(), name, description, isCompleted);
    }


}
