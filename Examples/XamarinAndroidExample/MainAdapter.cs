using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace XamarinAndroidExample
{
    //public class MainAdapter : RecyclerView.Adapter
    //{
    //    Context context;

    //    public MainAdapter(Context context) : base()
    //    {
    //        this.context = context;
    //    }

    //    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    //    {
    //        View vh = LayoutInflater.From(context).Inflate(Resource.Layout.layout_list_item, parent, false);
    //        return new MainAdapterViewHolder(vh);
    //    }

    //    public override long GetItemId(int position)
    //    {
    //        return position;
    //    }

    //    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    //    {
    //        var vh = (MainAdapterViewHolder)holder;
    //        //var item = _list[position];
    //    }

    //    public override int ItemCount => throw new NotImplementedException();
    //}

    //public class MainAdapterViewHolder : RecyclerView.ViewHolder
    //{
    //    private ImageView image;
    //    private TextView text;

    //    public MainAdapterViewHolder(View itemView) : base(itemView)
    //    {
    //        image = itemView.FindViewById<ImageView>(Resource.Id.image);
    //        text = itemView.FindViewById<TextView>(Resource.Id.text); 
    //    }
    //}
}