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
    public class MainAdapter : RecyclerView.Adapter
    {
        Context context;
        private List<string> _list;

        public MainAdapter(Context context, List<string> list) : base()
        {
            this.context = context;
            _list = list;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View vh = LayoutInflater.From(context).Inflate(Resource.Layout.list_item, parent, false);
            return new MainAdapterViewHolder(vh);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public void remove(int position)
        {
            _list.RemoveAt(position);
            NotifyItemRemoved(position);
        }

        public void add(string text, int position)
        {
            _list.Insert(position, text);
            NotifyItemInserted(position);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = (MainAdapterViewHolder)holder;
            vh.text.Text = _list[position];
            //var item = _list[position];
        }

        public override int ItemCount => _list.Count;

    }

    public class MainAdapterViewHolder : RecyclerView.ViewHolder
    {
        public ImageView image;
        public TextView text;

        public MainAdapterViewHolder(View itemView) : base(itemView)
        {
            image = itemView.FindViewById<ImageView>(Resource.Id.image);
            text = itemView.FindViewById<TextView>(Resource.Id.text);
        }
    }
}