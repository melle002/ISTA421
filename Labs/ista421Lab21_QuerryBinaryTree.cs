//--------------BinaryTree.cproj----------------
//----------------------------------------------
//-------------Tree.case Condition:

using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Tree<TItem> : IEnumerable<TItem> where TItem : IComparable<TItem>
    {
        public Tree(TItem nodeValue)
        {
            this.NodeData = nodeValue;
            this.LeftTree = null;
            this.RightTree = null;
        }

        public void Insert(TItem newItem)
        {
            TItem currentNodeValue = this.NodeData;
            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                if (this.LeftTree == null)
                {
                    this.LeftTree = new Tree<TItem>(newItem);
                }
                else
                {
                    this.LeftTree.Insert(newItem);
                }
            }
            else
            {
                if (this.RightTree == null)
                {
                    this.RightTree = new Tree<TItem>(newItem);
                }
                else
                {
                    this.RightTree.Insert(newItem);
                }
            }
        }

        public void WalkTree()
        {
            if (this.LeftTree != null)
            {
                this.LeftTree.WalkTree();
            }

            Console.WriteLine(this.NodeData.ToString());

            if (this.RightTree != null)
            {
                this.RightTree.WalkTree();
            }
        }

        public TItem NodeData { get; set; }
        public Tree<TItem> LeftTree { get; set; }
        public Tree<TItem> RightTree { get; set; }

        #region IEnumerable<TItem> Members

        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            if (this.LeftTree != null)
            {
                foreach (TItem item in this.LeftTree)
                {
                    yield return item;
                }
            }

            yield return this.NodeData;

            if (this.RightTree != null)
            {
                foreach (TItem item in this.RightTree)
                {
                    yield return item;
                }
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
//------------------QueryBunaryTree.cproj------------------
//---------------------------------------------------------
//-------------------Employee.cs---------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBinaryTree
{
    class Employee : IComparable<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public int Id { get; set; }

        public override string ToString() =>
            $"Id: {this.Id}, Name: {this.FirstName} {this.LastName}, Dept: {this.Department}";

        int IComparable<Employee>.CompareTo(Employee other)
        {
            if (other == null)
            {
                return 1;
            }

            if (this.Id > other.Id)
            {
                return 1;
            }

            if (this.Id < other.Id)
            {
                return -1;
            }

            return 0;
        }
    }
}
//---------------Program.cs---------------------------------------
using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBinaryTree
{
  class Program
  {
      static void doWork()
      {
          Tree<Employee> empTree = new Tree<Employee>(
              new Employee
              {
                  Id = 1,
                  FirstName = "Kim",
                  LastName = "Abercrombie",
                  Department = "IT"
              });

          empTree.Insert(
              new Employee
              {
                  Id = 2,
                  FirstName = "Jeff",
                  LastName = "Hay",
                  Department = "Marketing"
              });

          empTree.Insert(
              new Employee
              {
                  Id = 4,
                  FirstName = "Charlie",
                  LastName = "Herb",
                  Department = "IT"
              });

          empTree.Insert(
              new Employee
              {
                  Id = 6,
                  FirstName = "Chris",
                  LastName = "Preston",
                  Department = "Sales"
              });

          empTree.Insert(
              new Employee
              {
                  Id = 3,
                  FirstName = "Dave",
                  LastName = "Barnett",

                  Department = "Sales"
              });

          empTree.Insert(
              new Employee
              {
                  Id = 5,
                  FirstName = "Tim",
                  LastName = "Litton",
                  Department = "Marketing"
              });

          /*Console.WriteLine("List of departments");

          //var depts = empTree.Select(d => d.Department).Distinct();
          var depts = (from d in empTree
              select d.Department).Distinct();

          foreach (var dept in depts)
          {
              Console.WriteLine($"Department: {dept}");
          }

          Console.WriteLine();
          Console.WriteLine("Employees in the IT department");

          //var ITEmployees =
          // empTree.Where(e => String.Equals(e.Department, "IT"))
          // .Select(emp => emp);

          var ITEmployees = from e in empTree
              where String.Equals(e.Department, "IT")
              select e;

          foreach (var emp in ITEmployees)
          {
              Console.WriteLine(emp);
          }
          Console.WriteLine("");
          Console.WriteLine("All employees grouped by department");

          //var employeesByDept = empTree.GroupBy(e => e.Department);

          var employeesByDept = from e in empTree
              group e by e.Department;

          foreach (var dept in employeesByDept)
          {
              Console.WriteLine($"Department: {dept.Key}");
              foreach (var emp in dept)
              {
                  Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
              }
          }*/
          Console.WriteLine("All employees");
          var allEmployees = from e in empTree.ToList<Employee>()
              select e;

          foreach (var emp in allEmployees)
          {
              Console.WriteLine(emp);
          }
          empTree.Insert(new Employee
          {
              Id = 7,
              FirstName = "David",
              LastName = "Simpson",
              Department = "IT"
          });

          Console.WriteLine();
          Console.WriteLine("Employee added");

          Console.WriteLine("All employees");
          foreach (var emp in allEmployees)
          {
              Console.WriteLine(emp);
          }
      }

      static void Main()
      {
          try
          {
              doWork();
          }
          catch (Exception ex)
          {
              Console.WriteLine("Exception: {0}", ex.Message);
          }
      }
  }
}
