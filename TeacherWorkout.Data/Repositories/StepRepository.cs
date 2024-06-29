using System.Linq;
using Microsoft.EntityFrameworkCore;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Data.Repositories
{
    public class StepRepository: IStepRepository
    {
        private readonly TeacherWorkoutContext _context;

        public StepRepository(TeacherWorkoutContext context)
        {
            _context = context;
        }

        public ILessonStep Find(string id)
        {
            return _context.SlideSteps.Find(id);
        }

        public ILessonStep CompleteStep(string id)
        {
            var slideStep = _context.SlideSteps.Single(x => x.Id == id);

            slideStep.Lesson.State = LessonState.Published;

            _context.SaveChanges();

            return slideStep;
        }
    }
}
