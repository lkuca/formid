﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace formid
{




    public class Triangle
    {
        public double a;
        public double b;
        public double c;
        public Triangle(double A, double B, double C) 
        {
            a = A;
            b = B;
            c = C;
            
        }
        public string outputa()
        {
            return Convert .ToString(a);
        }
        public string outputb() 
        {
            return Convert.ToString(b);
        }
        public string outputc()
        {
            return Convert.ToString(c);
        }
        public int Perimeter()
        {
           
            double p = 0;
            p = a + b + c ;
            return (int)p;
        }
        public int Surface() 
        {
            
            double p = 0;
            double s = 0;
            p = (a + b + c) / 2;
            s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            return (int)s;
        }
        public double GetSetA
        {
            get
            {
                return a;
            }
            set { a = value; }
        }
        public double GetSetB
        {
            get
            { return b;}
            set { b = value; }
        }
        public double GetSetC
        {
            get
            { return c;}
            set
            {
                c = value;
            }
        }
        public bool ExistTriangle
        {
            get
            {
                if ((a < b + c)&&(b<a +c)&&(c< a+ b)) return true;else return false;
            }
        }
        public double Getkorgus()
        {
            if (ExistTriangle)
            {
                double p = (a + b + c) / 2;
                double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                double height = (2 * area) / a;
                return height;
            }
            else { return 0; }
            
        }
        public double GetMediaanA()
        {   
            
           double ma = Math.Sqrt(2 * b * b + 2 * c * c - a * a);
           double maa = 1 / 2 * (ma);
            return (int) maa;
            

        }
        public double GetMediaanB()
        {

            double mb = Math.Sqrt(2 * a * a + 2 * c * c - b * b);
            double mbb = 1 / 2 * (mb);
            return (int) mbb;


        }
        public double GetMediaanC()
        {

            double mc = Math.Sqrt(2 * a * a + 2 * b * b - c * c);
            double mcc = 1 / 2 * (mc);
            return (int) mcc;

        }


    }
    
}
