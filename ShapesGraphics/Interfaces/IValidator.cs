using ShapesGraphics.Models.ConstructionArgs;

namespace ShapesGraphics.Models.Validators
{
    public interface IValidator<T> where T : BaseConstructionArgs
    {
        void Validate(T constructionArgs);
    }
}
