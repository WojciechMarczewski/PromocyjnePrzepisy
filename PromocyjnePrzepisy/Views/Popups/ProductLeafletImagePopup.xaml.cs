using CommunityToolkit.Maui.Views;
namespace PromocyjnePrzepisy.Views.Popups;
public partial class ProductLeafletImagePopup : Popup
{
    double currentScale = 1;
    double startScale = 1;
    double xOffset = 0;
    double yOffset = 0;
    public ProductLeafletImagePopup(byte[] bytes)
    {
        InitializeComponent();
        this.LeafletImage.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
    }
    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        this.CloseAsync();
    }
    void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
#if ANDROID
        if (e.Status == GestureStatus.Started)
        {
            // Store the current scale factor applied to the wrapped user interface element,
            // and zero the components for the center point of the translate transform.
            startScale = LeafletImage.Scale;
            LeafletImage.AnchorX = 0;
            LeafletImage.AnchorY = 0;
        }
        if (e.Status == GestureStatus.Running)
        {
            // Calculate the scale factor to be applied.
            currentScale += (e.Scale - 1) * startScale;
            currentScale = Math.Max(1, currentScale);
            // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
            // so get the X pixel coordinate.
            double width = Application.Current.MainPage.Width;
            double height = Application.Current.MainPage.Height;
            double renderedX = LeafletImage.X + xOffset;
            double deltaX = renderedX / width;
            double deltaWidth = width / (LeafletImage.Width * startScale);
            double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;
            // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
            // so get the Y pixel coordinate.
            double renderedY = LeafletImage.Y + yOffset;
            double deltaY = renderedY / height;
            double deltaHeight = height / (LeafletImage.Height * startScale);
            double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;
            // Calculate the transformed element pixel coordinates.
            double targetX = xOffset - (originX * LeafletImage.Width) * (currentScale - startScale);
            double targetY = yOffset - (originY * LeafletImage.Height) * (currentScale - startScale);
            // Apply translation based on the change in origin.
            LeafletImage.TranslationX = Math.Clamp(targetX, -LeafletImage.Width * (currentScale - 1), 0);
            LeafletImage.TranslationY = Math.Clamp(targetY, -LeafletImage.Height * (currentScale - 1), 0);
            // Apply scale factor
            LeafletImage.Scale = currentScale;
        }
        if (e.Status == GestureStatus.Completed)
        {
            // Store the translation delta's of the wrapped user interface element.
            xOffset = LeafletImage.TranslationX;
            yOffset = LeafletImage.TranslationY;
        }
#endif
    }
}