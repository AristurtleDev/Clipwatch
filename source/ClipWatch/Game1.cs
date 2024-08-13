using System.Runtime.InteropServices;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace ClipWatch;

public class Game1 : Game
{
    [DllImport("user32.dll")]
    private static extern uint GetClipboardSequenceNumber();

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private uint _previousSequenceNumber;



    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        ToastNotificationManagerCompat.OnActivated += args =>
        {
            //  Do nothing
        };
        _previousSequenceNumber = GetClipboardSequenceNumber();
        
    }

    protected override void Update(GameTime gameTime)
    {
        uint currentSequenceNumber = GetClipboardSequenceNumber();
        if(_previousSequenceNumber != currentSequenceNumber)
        {
            _previousSequenceNumber = currentSequenceNumber;
           new ToastContentBuilder().AddText("Clipboard Copy Successful").Show();
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
    }
}
