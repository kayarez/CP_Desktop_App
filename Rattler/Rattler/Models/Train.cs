using System.ComponentModel.DataAnnotations;


namespace Rattler.Models
{
    public class Train
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string NumberTrain { get; set; }


        public Train()
        {

        }

        public Train(string type, string numberTrain)
        {
            Type = type;
            NumberTrain = numberTrain;

        }

    }
}
