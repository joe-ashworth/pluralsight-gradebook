using System;
using Xunit;

namespace GradeBook.Tests
{
  public class TypeTests
  {

    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
      var x = GetInt();
      setInt(ref x);

      Assert.Equal(42, x);
    }

    private void setInt(ref int x)
    {
      x = 42;
    }

    private int GetInt()
    {
      return 3;
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(ref book1, "New Name");

      Assert.Equal("New Name", book1.Name);
    }
    private void GetBookSetName(ref Book book, string name)
    {
      book = new Book(name);
    }

    [Fact]
    public void CSharpIsPassByValue()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(book1, "New Name");

      Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(Book book, string name)
    {
      book = new Book(name);
    }

    [Fact]
    public void CanSetNameFromReference()
    {
      var book1 = GetBook("Book 1");
      SetName(book1, "New Name");

      Assert.Equal("New Name", book1.Name);
    }

    private void SetName(Book book, string name)
    {
      book.Name = name;
    }

    [Fact]
    public void StringsBehaveLifeValueTypes()
    {
      string name = "Joe";
      var upper = MakeUppercase(name);

      Assert.Equal("JOE", upper);
      Assert.Equal("Joe", name);
    }

    private string MakeUppercase(string parameter)
    {
      return parameter.ToUpper();
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
      var book1 = GetBook("Book 1");
      var book2 = GetBook("Book 2");

      Assert.Equal("Book 1", book1.Name);
      Assert.Equal("Book 2", book2.Name);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
      var book1 = GetBook("Book 1");
      var book2 = book1;

      Assert.Same(book1, book2);
    }

    Book GetBook(string name)
    {
      return new Book(name);
    }
  }
}
