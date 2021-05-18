using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Models
{
    public class Data
    {
        public int DataId { get; set; }
        public string Pose { get; set; }
        public bool Target { get; set; }
        public int NoseX { get; set; }
        public int NoseY { get; set; }
        public int LeftEyeX { get; set; }
        public int LeftEyeY { get; set; }
        public int RightEyeX { get; set; }
        public int RightEyeY { get; set; }
        public int LeftEarX { get; set; }
        public int LeftEarY { get; set; }
        public int LeftShoulderX { get; set; }
        public int LeftShoulderY { get; set; }
        public int RightShoulderX { get; set; }
        public int RightShoulderY { get; set; }
        public int LeftElbowX { get; set; }
        public int LeftElbowY { get; set; }
        public int RightElbowX { get; set; }
        public int RightElbowY { get; set; }
        public int LeftWristX { get; set; }
        public int LeftWristY { get; set; }
        public int RightWristX { get; set; }
        public int RightWristY { get; set; }
        public int LeftHipX { get; set; }
        public int LeftHipY { get; set; }
        public int RightHipX { get; set; }
        public int RightHipY { get; set; }
        public int LeftKneeX { get; set; }
        public int LeftKneeY { get; set; }
        public int RightKneeX { get; set; }
        public int RightKneeY { get; set; }
        public int LeftAnkleX { get; set; }
        public int LeftAnkleY { get; set; }
        public int RightAnkleX { get; set; }
        public int RightAnkleY { get; set; }
    }
}
