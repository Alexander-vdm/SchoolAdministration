namespace SchoolAdministration;

public class ExceptionDemo
{
    public void IWillThrowAnException()
    {
        ThrowException();
    }

    private void ThrowException()
    {
        throw new Exception("Failed");
    }
}
