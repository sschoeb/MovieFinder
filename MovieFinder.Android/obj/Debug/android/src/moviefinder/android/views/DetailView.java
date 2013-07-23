package moviefinder.android.views;


public class DetailView
	extends cirrious.mvvmcross.droid.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MovieFinder.Android.Views.DetailView, MovieFinder.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DetailView.class, __md_methods);
	}


	public DetailView ()
	{
		super ();
		if (getClass () == DetailView.class)
			mono.android.TypeManager.Activate ("MovieFinder.Android.Views.DetailView, MovieFinder.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
