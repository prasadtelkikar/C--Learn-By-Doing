using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionAndBackTracking
    {
    public class TowerOfHonoi
        {
        public static void Main (string[] args)
            {
            int plates = Convert.ToInt32(Console.ReadLine());
            TowerOfHonoiFun(plates, 1, 3, 2);
            Console.ReadKey();
            }

        private static void TowerOfHonoiFun (int plates, int fromTower, int toTower, int auxTower)
            {
            //Only last plate can move
            if ( plates == 0 )
                {
                Console.WriteLine($"Move disk 1 from tower {fromTower} to tower {toTower}");
                return;
                }

            
            //Move top n - 1 disks from fromTower to toTower using auxilary 
            TowerOfHonoiFun(plates - 1, fromTower, auxTower, toTower);

            Console.WriteLine($"Move {plates} disk from tower {fromTower} to {toTower}");
            TowerOfHonoiFun(plates - 1, auxTower, toTower, fromTower);
            }
        }
    }
