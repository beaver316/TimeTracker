﻿using TimeTracker.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TimeTracker.Droid.Renderers;
using Android.Content;
using Android.Graphics;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(HoursProgressView), typeof(HoursProgressViewRenderer))]
namespace TimeTracker.Droid.Renderers
{
    public class HoursProgressViewRenderer : ViewRenderer
    {
        private HoursProgressView _view;

        public HoursProgressViewRenderer(Context context) : base(context)
        {
            SetWillNotDraw(false);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            _view = Element as HoursProgressView;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            var paint = new Paint();
            paint.Color = Color.Gray.ToAndroid();
            paint.StrokeWidth = Context.ToPixels(5);
            canvas.DrawLine(0, canvas.Height / 2, canvas.Width, canvas.Height / 2, paint);

            var currentProgressWidth = (_view.Current - _view.Min) / (_view.Max - _view.Min);
            paint.Color = Color.Blue.ToAndroid();
            canvas.DrawLine(0, canvas.Height / 2, (float)(canvas.Width * currentProgressWidth), canvas.Height / 2, paint);
        }
    }
}