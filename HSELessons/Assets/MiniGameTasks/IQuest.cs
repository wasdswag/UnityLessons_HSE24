
public interface IQuest
{
   bool IsActive { get; set; }
   bool IsComplete { get; set; }
   void SetComplete();
}
