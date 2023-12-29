using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    //main region class
    static class RegionManager
    {
        static List<IRegion> list = new List<IRegion>();
        static int IdCount = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------\nRegion Management System\n---------------------------\nEnter the options");
            Console.WriteLine("\n1. Add Region\n2. Remove Region\n3. GetAllRegions\n4. GetRegion\n5. Region Operations\n");
           
            int option = Convert.ToInt32(Console.ReadLine());

            switch(option)
            {
                case 1:
                    Console.WriteLine("\nEnter the shapes:\n1.Circle\n2.Rectangel\n3.Triangle\n");
                    int shapes = Convert.ToInt32(Console.ReadLine());
                    switch(shapes)
                    {
                        //inner case 1 for CIRCLE
                        case 1:
                            Console.WriteLine("\nEnter Circle Name:");
                            string cName = Console.ReadLine();

                            Console.WriteLine("\nEnter the radius:");
                            decimal radius = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\nEnter the Co-ordinate X:");
                            int cx = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\nEnter the Co-ordinate Y:");
                            int cy = Convert.ToInt32(Console.ReadLine());

                            if (AddRegion(cName,radius,cx,cy))
                            {
                                Console.WriteLine("\nRegion Addded successfully!");
                                
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid Input!\nFailed to add region.");
                            }
                            break;

                        //inner case 2 for RECTANGLE
                        case 2:
                            Console.WriteLine("\nEnter Rectangle Name:");
                            string rName = Console.ReadLine();

                            Console.WriteLine("\nEnter Length:");
                            decimal len = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\nEnter breadth:");
                            decimal breadth = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\nEnter the Co-ordinate X:");
                            int rx = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\nEnter the Co-ordinate Y:");
                            int ry = Convert.ToInt32(Console.ReadLine());

                            if (AddRegion(rName, len, breadth,rx,ry))
                            {
                                Console.WriteLine("\nRegion Addded successfully!");
                                
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid Input!\nFailed to add region.");
                            }
                            break;

                        //inner case 3 for TRIANGLE
                        case 3:
                            Console.WriteLine("\nEnter Triangle Name:");
                            string tName = Console.ReadLine();

                            Console.WriteLine("\nEnter Length:");
                            decimal triLen = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\nEnter height:");
                            decimal triHeight = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\nEnter the Co-ordinate X:");
                            int tx = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\nEnter the Co-ordinate Y:");
                            int ty = Convert.ToInt32(Console.ReadLine());

                            if (AddRegion( triLen, triHeight, tName,tx,ty))
                            {
                                Console.WriteLine("\nRegion Addded successfully!");
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid Input!\nFailed to add region.");
                            }
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("\nRemove using\n1.Id\n2.Name\n3.Region");
                    int remOption = Convert.ToInt32(Console.ReadLine());

                    switch(remOption)
                    {
                        case 1:
                            Console.WriteLine("\nEnter Id:");
                            byte idOp = (byte)Convert.ToInt32(Console.ReadLine());

                            if(RemoveRegion(idOp))
                            {
                                Console.WriteLine("Successfully Removed!");

                            }
                            else
                            {
                                Console.WriteLine("Can't find Id");
                            }

                            break;

                        case 2:
                            Console.WriteLine("\nEnter Region Name:");
                            string remName = Console.ReadLine();

                            if(RemoveRegion(remName))
                            {
                                Console.WriteLine("Successfully Removed!");

                            }
                            else
                            {
                                Console.WriteLine("Can't find Region Name");
                            }
                            break;
                        case 3:
                            Console.WriteLine("\nEnter Region No.:\n1.Circle\n2.Rectangle\n3.Triangle");
                            int regNo = Convert.ToInt32(Console.ReadLine());
                            switch(regNo)
                            {
                                case 1:
                                    if(RemoveRegion(new Circle()))
                                    {
                                        Console.WriteLine("Successfully Removed!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Can't find Region");
                                    }
                                    break;
                                case 2:
                                    if(RemoveRegion(new Rectangle()))
                                    {
                                        Console.WriteLine("Successfully Removed!");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Can't find Region");
                                    }

                                    break;
                                case 3:
                                    if(RemoveRegion(new Triangle()))
                                    {
                                        Console.WriteLine("Successfully Removed!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Can't find Region");
                                    }
                                    break;
                                    
                            }

                            break;
                            
                    }
                    break;
                case 3:
                    Console.WriteLine("\nThe Regions are:");
                    IReadOnlyList<IRegion> regions = GetAllRegions();

                    foreach(IRegion idx in regions)
                    {
                        Console.WriteLine("\nType: "+idx.GetType() +"\nID: " + idx.Id+ "\nName: " + idx.Name+"\nNo. of Edges: "+idx.NoOfEdges+"\nArea: "+idx.GetArea());
                        
                    }
                    break;
                case 4:
                    Console.WriteLine("\nEnter the ID you want to get");
                    int id = Convert.ToInt32(Console.ReadLine());

                    IRegion reg = GetRegion(id);
                    if (reg == null)
                    {
                        Console.WriteLine("\nId Not Available");
                    }
                    else
                    {
                        Console.WriteLine("\nType: " + reg.GetType() + "\nID: " + reg.Id + "\nName: " + reg.Name + "\nNo. of Edges: " + reg.NoOfEdges + "\nArea: " + reg.GetArea());
                    }
                    break;
                case 5:
                    Console.WriteLine("Which Region you need to operate?");
                    IReadOnlyList<IRegion> c5Regions = GetAllRegions();
                    foreach (IRegion idx in c5Regions)
                    {
                        Console.WriteLine("\nType: " + idx.GetType() + "\nID: " + idx.Id + "\nName: " + idx.Name + "\nNo. of Edges: " + idx.NoOfEdges + "\nArea: " + idx.GetArea());

                    }
                    Console.WriteLine("\nEnter it's ID:");
                    int c5Id = Convert.ToInt32(Console.ReadLine());
                    IRegion opReg = GetRegion(c5Id);
                    
                    Console.WriteLine("\nFunctions:\n1.GetArea()\n2.MoveRegion()\n3.Resize()\n4.Intersect()\n");
                    int funOp = Convert.ToInt32(Console.ReadLine());
                    switch (funOp)
                    {
                        case 1:
                            Console.WriteLine("The Area of the region of ID:"+c5Id+" is "+""+opReg.GetArea());
                            break;
                        case 2:
                            Console.WriteLine("Enter the Coordinate X");
                            int x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Coordinate Y");
                            int y = Convert.ToInt32(Console.ReadLine());

                            opReg.MoveRegion(x,y);
                            Console.WriteLine("\nSuccessfully Moved the Region");
                            break;
                        case 3:
                            Console.WriteLine("Enter the Coordinate X");
                            int x1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Coordinate Y");
                            int y1 = Convert.ToInt32(Console.ReadLine());

                            if(opReg.Resize(x1,y1))
                            {
                                Console.WriteLine("Resized Successfully");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter the another ID of the region to check intersection");
                            int checkId = Convert.ToInt32(Console.ReadLine());
                            IRegion checkIntersect = GetRegion(checkId);
                            if(opReg.Intersect(checkIntersect))
                            {
                                Console.WriteLine("The two region is intersecting between each other");
                            }
                            else
                            {
                                Console.WriteLine("The two region Does not intersects!!");
                            }
                            break;
                    }
                    //RegionOperations(opReg,funOp);


                    break;


            }
            Console.WriteLine("\nDo you want to continue? y/n");
            string str = Console.ReadLine();
            if (str == "y")
            {
                Main(null);
            }
            else
            {
                Console.WriteLine("\nThank You!");
                return;
            }

            Console.ReadKey();
        }
       
        static bool AddRegion(string cName, decimal radius,int x,int y)
        {
            if(radius<0)
            {
                return false;
            }

            Circle c = new Circle(radius);
            c.Id = IdCount++;
            c.Name = cName;
            c.x = x;
            c.y = y;

            list.Add(c);

            return true;
        }
        static bool AddRegion(string rName, decimal len, decimal breadth, int x, int y)
        {
            if(len<0 || breadth<0)
            {
                return false;
            }

            Rectangle r = new Rectangle(len, breadth);
            r.Id = IdCount++;
            r.Name = rName;
            r.x = x;
            r.y = y;

            list.Add(r);

            return true;
        }
        static bool AddRegion(decimal triLen, decimal triHeight, string tName, int x, int y)
        {
            if(triHeight<0 || triLen<0)
            {
                return false;
            }

            Triangle t = new Triangle(triLen, triHeight);
            t.Id = IdCount++;
            t.Name = tName;
            t.x = x;
            t.y = y;

            list.Add(t);

            return true;
        }
        

        static bool RemoveRegion(byte id)
        {
            List<int> ind = new List<int>();
            int k = 0;
            int flag = 0;
            foreach(IRegion i in list)
            {
                if(i.Id == id)
                {
                    ind.Add(k);
                    flag++;
                    
                }
                k++;
            }

            foreach(int ctr in ind)
            {
                list.RemoveAt(ctr);
            }

            return flag>0;
        }
        static bool RemoveRegion(string Name)
        {
            List<int> ind = new List<int>();
            int k = 0;
            int flag = 0;
            foreach (IRegion i in list)
            {
                if (i.Name == Name)
                {
                    ind.Add(k);
                    flag++;
                }
                k++;
            }
            foreach (int ctr in ind)
            {
                list.RemoveAt(ctr);
            }

            return flag>0;
        }
        static bool RemoveRegion(IRegion ir)
        {
            List<int> ind = new List<int>();
            int k = 0;
            int flag = 0;
            foreach (IRegion i in list)
            {
                if (i.GetType() == ir.GetType())
                {
                    ind.Add(k);
                    flag++;
                }
                k++;
            }
            foreach (int ctr in ind)
            {
                list.RemoveAt(ctr);
            }

            return flag>0 ;
        }
        static IReadOnlyList<IRegion> GetAllRegions()
        {
            return new List<IRegion>(list);


        }
        static IRegion GetRegion(int id)
        {
            
            foreach(IRegion i in list)
            {
                if(i.Id == id)
                {
                    return i;
                }
            }
            return null;
        }
        
    }

    
    
}
