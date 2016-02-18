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
using Android.Util;
using Android.Views;
using Android.Widget;
using Color = Android.Graphics.Color;

namespace WelStijl
{
    class RectangleShape : View
    {
        private RectF bounds = new RectF(0, 0, 0, 0);
        private Paint _paint;

        public void setPaint(Color color)
        {
            _paint.Color = color;
            PostInvalidate();
        }

        public RectangleShape(Context context, Color color) : base(context)
        {
            _paint = new Paint {Color = color};
        }

        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawCircle(bounds.CenterX(), bounds.CenterY(), bounds.CenterX(), _paint);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            MeasureSpecMode widthSpecMode = MeasureSpec.GetMode(widthMeasureSpec);
            int widthSpecSize = MeasureSpec.GetSize(widthMeasureSpec);
            MeasureSpecMode heightSpecMode = MeasureSpec.GetMode(heightMeasureSpec);
            int heightSpecSize = MeasureSpec.GetSize(heightMeasureSpec);

            int size;

            int widthWithoutPadding = widthSpecSize - PaddingLeft - PaddingRight;
            int heightWithoutPadding = heightSpecSize - PaddingTop - PaddingBottom;

            if (widthSpecMode == MeasureSpecMode.Unspecified && heightSpecMode != MeasureSpecMode.Unspecified)
            {
                size = heightWithoutPadding;
            }
            else if (widthSpecMode != MeasureSpecMode.Unspecified && heightSpecMode == MeasureSpecMode.Unspecified)
            {
                size = widthWithoutPadding;
            }
            else if (widthSpecMode == MeasureSpecMode.Unspecified && heightSpecMode == MeasureSpecMode.Unspecified)
            {
                size = Math.Max(widthWithoutPadding, heightWithoutPadding);
            }
            else {
                if (widthWithoutPadding > heightWithoutPadding)
                {
                    size = heightWithoutPadding;
                }
                else {
                    size = widthWithoutPadding;
                }
            }

            SetMeasuredDimension(size + PaddingLeft + PaddingRight, size + PaddingTop + PaddingBottom);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            float xpad = (float)(PaddingLeft + PaddingRight);
            float ypad = (float)(PaddingTop + PaddingBottom);

            float ww = (float)w - xpad;
            float hh = (float)h - ypad;

            bounds = new RectF(0f, 0f, ww, hh);
            bounds.OffsetTo(PaddingLeft, PaddingTop);
        }
    }
}