using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp_Fakes_Shims_Demo
{
    class Plane1:IPlane
    {
        private PictureBox _Pb;

        public PictureBox pb
        {
            get
            {
                return _Pb;
            }
            set
            {
                _Pb = value;
            }
        }

        private int _PetrolAmount;
        public int petrolAmount
        {
            get
            {
                return _PetrolAmount;
            }
            set
            {
                _PetrolAmount = value;
            }
        }

        public Plane1(PictureBox pb)
        {
            this.pb = pb;
            this.petrolAmount = 100;
        }

        public void moveRight()
        {            
            pb.BeginInvoke((Action)(() =>
            {
                pb.SetBounds(pb.Location.X + 10, pb.Location.Y, pb.Width, pb.Height);
            }));
        }

        public void petrolUse()
        {
            petrolAmount -= 10;
        }


        public int getBoundingBoxRight()
        {
            return pb.Right;
        }
    }

    class Plane2:IPlane
    {

        private PictureBox _Pb;

        public PictureBox pb
        {
            get
            {
                return _Pb;
            }
            set
            {
                _Pb = value;
            }
        }

        private int _PetrolAmount;
        public int petrolAmount
        {
            get
            {
                return _PetrolAmount;
            }
            set
            {
                _PetrolAmount = value;
            }
        }

        public Plane2(PictureBox pb)
        {
            this.pb = pb;
        }

        public void moveRight()
        {
            pb.BeginInvoke((Action)(() =>
            {
                pb.SetBounds(pb.Location.X + 10, pb.Location.Y, pb.Width, pb.Height);
            }));
        }

        public void petrolUse()
        {
            petrolAmount -= 10;
        }


        public int getBoundingBoxRight()
        {
            return pb.Right;
        }
    }
}
