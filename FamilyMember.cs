


using System.Xml.Linq;

namespace HW3
{
  public class FamilyMember
  {
    public string? Name { get; set; }
    public Sex Sex { get; set; }
    private FamilyMember? Father { get; set; }
    private FamilyMember? Mother { get; set; }
    private FamilyMember[]? Children { get; set; }

    public FamilyMember()
    {
    }

    public FamilyMember(string name, Sex sex, FamilyMember father, FamilyMember mother, params FamilyMember[] children)
    {
      this.Name = name;
      this.Sex = sex;
      this.Father = father;
      this.Mother = mother;
      this.Children = children;
    }

    public void AddChildren(FamilyMember child)
    {
      List<FamilyMember> siblings = [];

      if (Children != null)
        siblings.AddRange(Children);

      siblings.Add(child);
      Children = siblings.ToArray();
    }

    public void PrintCloseFamily()
    {
      PrintHasbendsOrWifes(this.Sex == Sex.Female ? Sex.Male : Sex.Female);
      
      PrintSiblings();
    }

    private void PrintSiblings()
    {
      List<FamilyMember> siblings = GetSiblings();
      if (siblings.Count > 0)
      {
        Console.Write("Братья и сёстры: ");

        foreach (FamilyMember sibling in siblings)
          Console.Write($"{sibling.Name} ");

        Console.WriteLine();
      }
    }

    private List<FamilyMember> GetSiblings()
    {
      List<FamilyMember> siblings = [];

      if (this.Mother != null && this.Mother.Children != null)
        siblings.AddRange(this.Mother.Children);

      if (this.Father != null && this.Father.Children != null)
        siblings.AddRange(this.Father.Children);

      while (siblings.Contains(this))
        siblings.Remove(this);

      return siblings;
    }

    private void PrintHasbendsOrWifes(Sex sex)
    {
      List<FamilyMember> hasbendsOrWifes = GetListOfHasbendsOrWifes(sex);
      
      if (hasbendsOrWifes.Count > 0)
      {
        if (sex == Sex.Female)
          Console.Write("Жёны: ");
        else
          Console.Write("Мужья: ");

        foreach (FamilyMember hasbendOrWife in hasbendsOrWifes)
          Console.Write($"{hasbendOrWife.Name} ");

        Console.WriteLine();
      }
    }

    private List<FamilyMember> GetListOfHasbendsOrWifes(Sex sex)
    {
      List<FamilyMember> hasbendsOrWifes = [];

      if (Children != null)
      {
        foreach (FamilyMember child in Children)
          if (child.Father != null && child.Father.Sex == sex && !hasbendsOrWifes.Contains(child.Father))
            hasbendsOrWifes.Add(child.Father);
          else if (child.Mother != null && child.Mother.Sex == sex && !hasbendsOrWifes.Contains(child.Mother))
            hasbendsOrWifes.Add(child.Mother);

        while (hasbendsOrWifes.Contains(this))
          hasbendsOrWifes.Remove(this);
      }

      return hasbendsOrWifes;
    }
  }
}

