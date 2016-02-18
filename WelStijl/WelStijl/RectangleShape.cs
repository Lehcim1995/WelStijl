using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Color = Android.Graphics.Color;

namespace WelStijl
{
    class RectangleShape : View
    {
        private readonly ShapeDrawable _shape;

        public RectangleShape(Context context, Color color) : base(context)
        {
            var paint = new Paint();
            paint.Color = color;
            paint.SetStyle(Paint.Style.Fill);

            _shape = new ShapeDrawable(new RectShape());
            _shape.Paint.Set(paint);
        }

        protected override void OnDraw(Canvas canvas)
        {
            _shape.Draw(canvas);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            _shape.SetBounds(0,0,w,h);
        }
    }
}