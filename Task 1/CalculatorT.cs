public class Calculator<T>
{
    public delegate T AddDelegate(T a, T b);
    public delegate T SubtractDelegate(T a, T b);
    public delegate T MultiplyDelegate(T a, T b);
    public delegate T DivideDelegate(T a, T b);

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public event AddDelegate OnAdd;
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public event SubtractDelegate OnSubtract;
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
    public event MultiplyDelegate OnMultiply = (a, b) => default;
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public event DivideDelegate OnDivide;
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

    public T Add(T a, T b)
    {
        if (OnAdd != null)
            return OnAdd(a, b);
        else
            throw new InvalidOperationException("Addition operation is not supported.");
    }

    public T Subtract(T a, T b)
    {
        if (OnSubtract != null)
            return OnSubtract(a, b);
        else
            throw new InvalidOperationException("Subtraction operation is not supported.");
    }

    public T Multiply(T a, T b)
    {
        if (OnMultiply != null)
            return OnMultiply(a, b);
        else
            throw new InvalidOperationException("Multiplication operation is not supported.");
    }

    public T Divide(T a, T b)
    {
        if (OnDivide != null)
            return OnDivide(a, b);
        else
            throw new InvalidOperationException("Division operation is not supported.");
    }
}