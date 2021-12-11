using Sample.Business.Base;
using Sample.DataAccess;
using Sample.Model;

namespace Sample.Business.Businesses;

public class SectionBusiness : BaseBusiness<Section>
{
	public SectionBusiness(SampleContext context) : base(context) { }
}

