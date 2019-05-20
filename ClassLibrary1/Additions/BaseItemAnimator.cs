using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Support.V7.Widget;
using Java.Interop;

namespace JP.Wasabeef.Recyclerview.Animators
{
    public partial class BaseItemAnimator
    {
        BaseItemAnimatorInvoker _baseItemAnimatorInvoker;

        public unsafe override bool AnimateAppearance(RecyclerView.ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo)
        {
            _baseItemAnimatorInvoker = new BaseItemAnimatorInvoker(this.Handle);    

            _baseItemAnimatorInvoker.AnimateAppearance()

            return JP.Wasabeef.Recyclerview.Animators.BaseItemAnimatorInvoker.AnimatePersistence(viewHolder, preLayoutInfo, postLayoutInfo);
        }

        public override bool AnimateChange(RecyclerView.ViewHolder oldHolder, RecyclerView.ViewHolder newHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo)
        {
            throw new NotImplementedException();
        }

        public override bool AnimateDisappearance(RecyclerView.ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo)
        {
            return AnimateDisappearance(viewHolder, preLayoutInfo, postLayoutInfo);
        }

        public override bool AnimatePersistence(RecyclerView.ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo)
        {
            return AnimatePersistence(viewHolder, preLayoutInfo, postLayoutInfo);
        }
    }
}