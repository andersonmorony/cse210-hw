using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Sr Software Engineer";
        job1._company = "Avanade";
        job1._startYear = "2017";
        job1._endYear = "2022";

        Job job2 = new Job();
        job2._jobTitle = "Sr Software Engineer";
        job2._company = "Jump Label";
        job2._startYear = "2023";
        job2._endYear = "Current";

        Resume myResume = new Resume();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._name = "Anderson Moroni";
        myResume.DisplayResumeDetails();
    }
}