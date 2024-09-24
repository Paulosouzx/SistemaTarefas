using SistemaTarefas.Enums;

namespace SistemaTarefas.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTarefa Status{ get; set; }
        public int? UserID { get; set; }

        public virtual UserModel? User { get; set; }
    }
}
