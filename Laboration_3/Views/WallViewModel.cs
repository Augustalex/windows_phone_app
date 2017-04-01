using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Laboration_3.Views
{
    class WallViewModel
    {
        public WallViewModel(int wallId = 0)
        {
            RoomId = -1;
            WallId = wallId;
            checkTypeOfWall(wallId);
        }
        public WallViewModel(int roomId, int wallId = 0)
        {
            this.RoomId = roomId;
            WallId = wallId;
            checkTypeOfWall(wallId);
        }

        private void checkTypeOfWall(int wallId)
        {
            switch (wallId)
            {
                case 0:
                    Title = "North Wall";
                    break;
                case 1:
                    Title = "East Wall";
                    break;
                case 2:
                    Title = "South Wall";
                    break;
                case 3:
                    Title = "West Wall";
                    break;
                case 4:
                    Title = "Floor";
                    break;
                case 5:
                    Title = "Roof";
                    break;
                default:
                    Debug.Write("Invalid ID");
                    break;
            }
        }

        public int RoomId { get; set; }

        public int WallId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
