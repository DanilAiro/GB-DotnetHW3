namespace HW3
{
  internal class Program
  {
    static void Main(string[] args)
    {
      FamilyMember grandFather1 = new("grandFather1", Sex.Male, null, null, null);
      FamilyMember grandMother1 = new("grandMother1", Sex.Female, null, null, null);
      FamilyMember father1 = new("father1", Sex.Male, grandFather1, grandMother1, null);
      FamilyMember father2 = new("father2", Sex.Male, grandFather1, null, null);
      FamilyMember mother1 = new("mother1", Sex.Female, null, grandMother1, null);
      grandFather1.AddChildren(father1);
      grandMother1.AddChildren(father1);
      grandMother1.AddChildren(father2);
      grandFather1.AddChildren(mother1);

      grandMother1.PrintCloseFamily();
    }
  }
}
