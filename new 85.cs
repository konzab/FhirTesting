#region Assembly Hl7.Fhir.R4, Version=5.3.0.0, Culture=neutral, PublicKeyToken=d706911480550fc3
// location unknown
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Validation;

namespace Hl7.Fhir.Model
{
    /// <summary>
    /// Information about an individual or animal receiving health care services
    /// </summary>
    [Serializable]
    [DataContract]
    [FhirType("Patient", "http://hl7.org/fhir/StructureDefinition/Patient", IsResource = true)]
    public class Patient : DomainResource, IPatient, IIdentifiable<List<Identifier>>, IIdentifiable
    {
        /// <summary>
        /// The type of link between this patient resource and another patient resource.
        /// (url: http://hl7.org/fhir/ValueSet/link-type)
        /// (system: http://hl7.org/fhir/link-type)
        /// </summary>
        [FhirEnumeration("LinkType", "http://hl7.org/fhir/ValueSet/link-type", "http://hl7.org/fhir/link-type")]
        public enum LinkType
        {
            /// <summary>
            /// The patient resource containing this link must no longer be used. The link points forward to another patient resource that must be used in lieu of the patient resource that contains this link.
            /// (system: http://hl7.org/fhir/link-type)
            /// </summary>
            [EnumLiteral("replaced-by", null)]
            [Description("Replaced-by")]
            ReplacedBy,
            /// <summary>
            /// The patient resource containing this link is the current active patient record. The link points back to an inactive patient resource that has been merged into this resource, and should be consulted to retrieve additional referenced information.
            /// (system: http://hl7.org/fhir/link-type)
            /// </summary>
            [EnumLiteral("replaces", null)]
            [Description("Replaces")]
            Replaces,
            /// <summary>
            /// The patient resource containing this link is in use and valid but not considered the main source of information about a patient. The link points forward to another patient resource that should be consulted to retrieve additional patient information.
            /// (system: http://hl7.org/fhir/link-type)
            /// </summary>
            [EnumLiteral("refer", null)]
            [Description("Refer")]
            Refer,
            /// <summary>
            /// The patient resource containing this link is in use and valid, but points to another patient resource that is known to contain data about the same person. Data in this resource might overlap or contradict information found in the other patient resource. This link does not indicate any relative importance of the resources concerned, and both should be regarded as equally valid.
            /// (system: http://hl7.org/fhir/link-type)
            /// </summary>
            [EnumLiteral("seealso", null)]
            [Description("See also")]
            Seealso
        }

        /// <summary>
        /// A contact party (e.g. guardian, partner, friend) for the patient
        /// </summary>
        [Serializable]
        [DataContract]
        [FhirType("Patient#Contact", IsNestedType = true)]
        [BackboneType("Patient.contact")]
        public class ContactComponent : BackboneElement
        {
            private List<CodeableConcept> _Relationship;

            private HumanName _Name;

            private List<ContactPoint> _Telecom;

            private Address _Address;

            private Code<AdministrativeGender> _GenderElement;

            private ResourceReference _Organization;

            private Period _Period;

            /// <summary>
            /// FHIR Type Name
            /// </summary>
            public override string TypeName => "Patient#Contact";

            /// <summary>
            /// The kind of relationship
            /// </summary>
            [FhirElement("relationship", Order = 40)]
            [Binding("ContactRelationship")]
            [Cardinality(Min = 0, Max = -1)]
            [DataMember]
            public List<CodeableConcept> Relationship
            {
                get
                {
                    if (_Relationship == null)
                    {
                        _Relationship = new List<CodeableConcept>();
                    }

                    return _Relationship;
                }
                set
                {
                    _Relationship = value;
                    OnPropertyChanged("Relationship");
                }
            }

            /// <summary>
            /// A name associated with the contact person
            /// </summary>
            [FhirElement("name", Order = 50)]
            [DataMember]
            public HumanName Name
            {
                get
                {
                    return _Name;
                }
                set
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }

            /// <summary>
            /// A contact detail for the person
            /// </summary>
            [FhirElement("telecom", Order = 60)]
            [Cardinality(Min = 0, Max = -1)]
            [DataMember]
            public List<ContactPoint> Telecom
            {
                get
                {
                    if (_Telecom == null)
                    {
                        _Telecom = new List<ContactPoint>();
                    }

                    return _Telecom;
                }
                set
                {
                    _Telecom = value;
                    OnPropertyChanged("Telecom");
                }
            }

            /// <summary>
            /// Address for the contact person
            /// </summary>
            [FhirElement("address", Order = 70)]
            [DataMember]
            public Address Address
            {
                get
                {
                    return _Address;
                }
                set
                {
                    _Address = value;
                    OnPropertyChanged("Address");
                }
            }

            /// <summary>
            /// male | female | other | unknown
            /// </summary>
            [FhirElement("gender", Order = 80)]
            [DeclaredType(Type = typeof(Code))]
            [Binding("AdministrativeGender")]
            [DataMember]
            public Code<AdministrativeGender> GenderElement
            {
                get
                {
                    return _GenderElement;
                }
                set
                {
                    _GenderElement = value;
                    OnPropertyChanged("GenderElement");
                }
            }

            /// <summary>
            /// male | female | other | unknown
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [IgnoreDataMember]
            public AdministrativeGender? Gender
            {
                get
                {
                    if (GenderElement == null)
                    {
                        return null;
                    }

                    return GenderElement.Value;
                }
                set
                {
                    if (!value.HasValue)
                    {
                        GenderElement = null;
                    }
                    else
                    {
                        GenderElement = new Code<AdministrativeGender>(value);
                    }

                    OnPropertyChanged("Gender");
                }
            }

            /// <summary>
            /// Organization that is associated with the contact
            /// </summary>
            [FhirElement("organization", Order = 90)]
            [CLSCompliant(false)]
            [References(new string[] { "Organization" })]
            [DataMember]
            public ResourceReference Organization
            {
                get
                {
                    return _Organization;
                }
                set
                {
                    _Organization = value;
                    OnPropertyChanged("Organization");
                }
            }

            /// <summary>
            /// The period during which this contact person or organization is valid to be contacted relating to this patient
            /// </summary>
            [FhirElement("period", Order = 100)]
            [DataMember]
            public Period Period
            {
                get
                {
                    return _Period;
                }
                set
                {
                    _Period = value;
                    OnPropertyChanged("Period");
                }
            }

            [IgnoreDataMember]
            public override IEnumerable<Base> Children
            {
                get
                {
                    foreach (Base child in base.Children)
                    {
                        yield return child;
                    }

                    foreach (CodeableConcept item in Relationship)
                    {
                        if (item != null)
                        {
                            yield return item;
                        }
                    }

                    if (Name != null)
                    {
                        yield return Name;
                    }

                    foreach (ContactPoint item2 in Telecom)
                    {
                        if (item2 != null)
                        {
                            yield return item2;
                        }
                    }

                    if (Address != null)
                    {
                        yield return Address;
                    }

                    if (GenderElement != null)
                    {
                        yield return GenderElement;
                    }

                    if (Organization != null)
                    {
                        yield return Organization;
                    }

                    if (Period != null)
                    {
                        yield return Period;
                    }
                }
            }

            [IgnoreDataMember]
            public override IEnumerable<ElementValue> NamedChildren
            {
                get
                {
                    foreach (ElementValue namedChild in base.NamedChildren)
                    {
                        yield return namedChild;
                    }

                    foreach (CodeableConcept item in Relationship)
                    {
                        if (item != null)
                        {
                            yield return new ElementValue("relationship", item);
                        }
                    }

                    if (Name != null)
                    {
                        yield return new ElementValue("name", Name);
                    }

                    foreach (ContactPoint item2 in Telecom)
                    {
                        if (item2 != null)
                        {
                            yield return new ElementValue("telecom", item2);
                        }
                    }

                    if (Address != null)
                    {
                        yield return new ElementValue("address", Address);
                    }

                    if (GenderElement != null)
                    {
                        yield return new ElementValue("gender", GenderElement);
                    }

                    if (Organization != null)
                    {
                        yield return new ElementValue("organization", Organization);
                    }

                    if (Period != null)
                    {
                        yield return new ElementValue("period", Period);
                    }
                }
            }

            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                ContactComponent contactComponent = other as ContactComponent;
                if (contactComponent == null)
                {
                    throw new ArgumentException("Can only copy to an object of the same type", "other");
                }

                base.CopyTo((IDeepCopyable)contactComponent);
                if (Relationship != null)
                {
                    contactComponent.Relationship = new List<CodeableConcept>(Relationship.DeepCopy());
                }

                if (Name != null)
                {
                    contactComponent.Name = (HumanName)Name.DeepCopy();
                }

                if (Telecom != null)
                {
                    contactComponent.Telecom = new List<ContactPoint>(Telecom.DeepCopy());
                }

                if (Address != null)
                {
                    contactComponent.Address = (Address)Address.DeepCopy();
                }

                if (GenderElement != null)
                {
                    contactComponent.GenderElement = (Code<AdministrativeGender>)GenderElement.DeepCopy();
                }

                if (Organization != null)
                {
                    contactComponent.Organization = (ResourceReference)Organization.DeepCopy();
                }

                if (Period != null)
                {
                    contactComponent.Period = (Period)Period.DeepCopy();
                }

                return contactComponent;
            }

            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new ContactComponent());
            }

            /// <inheritdoc />
            public override bool Matches(IDeepComparable other)
            {
                ContactComponent contactComponent = other as ContactComponent;
                if (contactComponent == null)
                {
                    return false;
                }

                if (!base.Matches((IDeepComparable)contactComponent))
                {
                    return false;
                }

                if (!Relationship.Matches(contactComponent.Relationship))
                {
                    return false;
                }

                if (!DeepComparable.Matches((IDeepComparable)Name, (IDeepComparable)contactComponent.Name))
                {
                    return false;
                }

                if (!Telecom.Matches(contactComponent.Telecom))
                {
                    return false;
                }

                if (!DeepComparable.Matches((IDeepComparable)Address, (IDeepComparable)contactComponent.Address))
                {
                    return false;
                }

                if (!DeepComparable.Matches((IDeepComparable)GenderElement, (IDeepComparable)contactComponent.GenderElement))
                {
                    return false;
                }

                if (!DeepComparable.Matches((IDeepComparable)Organization, (IDeepComparable)contactComponent.Organization))
                {
                    return false;
                }

                if (!DeepComparable.Matches((IDeepComparable)Period, (IDeepComparable)contactComponent.Period))
                {
                    return false;
                }

                return true;
            }

            public override bool IsExactly(IDeepComparable other)
            {
                ContactComponent contactComponent = other as ContactComponent;
                if (contactComponent == null)
                {
                    return false;
                }

                if (!base.IsExactly((IDeepComparable)contactComponent))
                {
                    return false;
                }

                if (!Relationship.IsExactly(contactComponent.Relationship))
                {
                    return false;
                }

                if (!DeepComparable.IsExactly((IDeepComparable)Name, (IDeepComparable)contactComponent.Name))
                {
                    return false;
                }

                if (!Telecom.IsExactly(contactComponent.Telecom))
                {
                    return false;
                }

                if (!DeepComparable.IsExactly((IDeepComparable)Address, (IDeepComparable)contactComponent.Address))
                {
                    return false;
                }

                if (!DeepComparable.IsExactly((IDeepComparable)GenderElement, (IDeepComparable)contactComponent.GenderElement))
                {
                    return false;
                }

                if (!DeepComparable.IsExactly((IDeepComparable)Organization, (IDeepComparable)contactComponent.Organization))
                {
                    return false;
                }

                if (!DeepComparable.IsExactly((IDeepComparable)Period, (IDeepComparable)contactComponent.Period))
                {
                    return false;
                }

                return true;
            }

            protected override bool TryGetValue(string key, out object value)
            {
                if (key != null)
                {
                    switch (key.Length)
                    {
                        case 12:
                            switch (key[0])
                            {
                                case 'r':
                                    if (!(key == "relationship"))
                                    {
                                        break;
                                    }

                                    value = Relationship;
                                    return Relationship?.Any() ?? false;
                                case 'o':
                                    if (!(key == "organization"))
                                    {
                                        break;
                                    }

                                    value = Organization;
                                    return Organization != null;
                            }

                            break;
                        case 7:
                            switch (key[0])
                            {
                                case 't':
                                    if (!(key == "telecom"))
                                    {
                                        break;
                                    }

                                    value = Telecom;
                                    return Telecom?.Any() ?? false;
                                case 'a':
                                    if (!(key == "address"))
                                    {
                                        break;
                                    }

                                    value = Address;
                                    return Address != null;
                            }

                            break;
                        case 6:
                            switch (key[0])
                            {
                                case 'g':
                                    if (!(key == "gender"))
                                    {
                                        break;
                                    }

                                    value = GenderElement;
                                    return GenderElement != null;
                                case 'p':
                                    if (!(key == "period"))
                                    {
                                        break;
                                    }

                                    value = Period;
                                    return Period != null;
                            }

                            break;
                        case 4:
                            if (!(key == "name"))
                            {
                                break;
                            }

                            value = Name;
                            return Name != null;
                    }
                }

                return base.TryGetValue(key, out value);
            }

            protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
            {
                foreach (KeyValuePair<string, object> elementPair in base.GetElementPairs())
                {
                    yield return elementPair;
                }

                if (Relationship?.Any() ?? false)
                {
                    yield return new KeyValuePair<string, object>("relationship", Relationship);
                }

                if (Name != null)
                {
                    yield return new KeyValuePair<string, object>("name", Name);
                }

                if (Telecom?.Any() ?? false)
                {
                    yield return new KeyValuePair<string, object>("telecom", Telecom);
                }

                if (Address != null)
                {
                    yield return new KeyValuePair<string, object>("address", Address);
                }

                if (GenderElement != null)
                {
                    yield return new KeyValuePair<string, object>("gender", GenderElement);
                }

                if (Organization != null)
                {
                    yield return new KeyValuePair<string, object>("organization", Organization);
                }

                if (Period != null)
                {
                    yield return new KeyValuePair<string, object>("period", Period);
                }
            }
        }

        /// <summary>
        /// A language which may be used to communicate with the patient about his or her health
        /// </summary>
        [Serializable]
        [DataContract]
        [FhirType("Patient#Communication", IsNestedType = true)]
        [BackboneType("Patient.communication")]
        public class CommunicationComponent : BackboneElement
        {
            private CodeableConcept _Language;

            private FhirBoolean _PreferredElement;

            /// <summary>
            /// FHIR Type Name
            /// </summary>
            public override string TypeName => "Patient#Communication";

            /// <summary>
            /// The language which can be used to communicate with the patient about his or her health
            /// </summary>
            [FhirElement("language", Order = 40)]
            [Binding("Language")]
            [Cardinality(Min = 1, Max = 1)]
            [DataMember]
            public CodeableConcept Language
            {
                get
                {
                    return _Language;
                }
                set
                {
                    _Language = value;
                    OnPropertyChanged("Language");
                }
            }

            /// <summary>
            /// Language preference indicator
            /// </summary>
            [FhirElement("preferred", Order = 50)]
            [DataMember]
            public FhirBoolean PreferredElement
            {
                get
                {
                    return _PreferredElement;
                }
                set
                {
                    _PreferredElement = value;
                    OnPropertyChanged("PreferredElement");
                }
            }

            /// <summary>
            /// Language preference indicator
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [IgnoreDataMember]
            public bool? Preferred
            {
                get
                {
                    if (PreferredElement == null)
                    {
                        return null;
                    }

                    return PreferredElement.Value;
                }
                set
                {
                    if (!value.HasValue)
                    {
                        PreferredElement = null;
                    }
                    else
                    {
                        PreferredElement = new FhirBoolean(value);
                    }

                    OnPropertyChanged("Preferred");
                }
            }

            [IgnoreDataMember]
            public override IEnumerable<Base> Children
            {
                get
                {
                    foreach (Base child in base.Children)
                    {
                        yield return child;
                    }

                    if (Language != null)
                    {
                        yield return Language;
                    }

                    if (PreferredElement != null)
                    {
                        yield return PreferredElement;
                    }
                }
            }

            [IgnoreDataMember]
            public override IEnumerable<ElementValue> NamedChildren
            {
                get
                {
                    foreach (ElementValue namedChild in base.NamedChildren)
                    {
                        yield return namedChild;
                    }

                    if (Language != null)
                    {
                        yield return new ElementValue("language", Language);
                    }

                    if (PreferredElement != null)
                    {
                        yield return new ElementValue("preferred", PreferredElement);
                    }
                }
            }

            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                CommunicationComponent communicationComponent = other as CommunicationComponent;
                if (communicationComponent == null)
                {
                    throw new ArgumentException("Can only copy to an object of the same type", "other");
                }

                base.CopyTo((IDeepCopyable)communicationComponent);
                if (Language != null)
                {
                    communicationComponent.Language = (CodeableConcept)Language.DeepCopy();
                }

                if (PreferredElement != null)
                {
                    communicationComponent.PreferredElement = (FhirBoolean)PreferredElement.DeepCopy();
                }

                return communicationComponent;
            }

            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new CommunicationComponent());
            }

            /// <inheritdoc />
            public override bool Matches(IDeepComparable other)
            {
                CommunicationComponent communicationComponent = other as CommunicationComponent;
                if (communicationComponent == null)
                {
                    return false;
                }

                if (!base.Matches((IDeepComparable)communicationComponent))
                {
                    return false;
                }

                if (!DeepComparable.Matches((IDeepComparable)Language, (IDeepComparable)communicationComponent.Language))
                {
                    return false;
                }

                if (!DeepComparable.Matches((IDeepComparable)PreferredElement, (IDeepComparable)communicationComponent.PreferredElement))
                {
                    return false;
                }

                return true;
            }

            public override bool IsExactly(IDeepComparable other)
            {
                CommunicationComponent communicationComponent = other as CommunicationComponent;
                if (communicationComponent == null)
                {
                    return false;
                }

                if (!base.IsExactly((IDeepComparable)communicationComponent))
                {
                    return false;
                }

                if (!DeepComparable.IsExactly((IDeepComparable)Language, (IDeepComparable)communicationComponent.Language))
                {
                    return false;
                }

                if (!DeepComparable.IsExactly((IDeepComparable)PreferredElement, (IDeepComparable)communicationComponent.PreferredElement))
                {
                    return false;
                }

                return true;
            }

            protected override bool TryGetValue(string key, out object value)
            {
                if (!(key == "language"))
                {
                    if (key == "preferred")
                    {
                        value = PreferredElement;
                        return PreferredElement != null;
                    }

                    return base.TryGetValue(key, out value);
                }

                value = Language;
                return Language != null;
            }

            protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
            {
                foreach (KeyValuePair<string, object> elementPair in base.GetElementPairs())
                {
                    yield return elementPair;
                }

                if (Language != null)
                {
                    yield return new KeyValuePair<string, object>("language", Language);
                }

                if (PreferredElement != null)
                {
                    yield return new KeyValuePair<string, object>("preferred", PreferredElement);
                }
            }
        }

        /// <summary>
        /// Link to another patient resource that concerns the same actual person
        /// </summary>
        [Serializable]
        [DataContract]
        [FhirType("Patient#Link", IsNestedType = true)]
        [BackboneType("Patient.link")]
        public class LinkComponent : BackboneElement
        {
            private ResourceReference _Other;

            private Code<LinkType> _TypeElement;

            /// <summary>
            /// FHIR Type Name
            /// </summary>
            public override string TypeName => "Patient#Link";

            /// <summary>
            /// The other patient or related person resource that the link refers to
            /// </summary>
            [FhirElement("other", InSummary = true, Order = 40)]
            [CLSCompliant(false)]
            [References(new string[] { "Patient", "RelatedPerson" })]
            [Cardinality(Min = 1, Max = 1)]
            [DataMember]
            public ResourceReference Other
            {
                get
                {
                    return _Other;
                }
                set
                {
                    _Other = value;
                    OnPropertyChanged("Other");
                }
            }

            /// <summary>
            /// replaced-by | replaces | refer | seealso
            /// </summary>
            [FhirElement("type", InSummary = true, Order = 50)]
            [DeclaredType(Type = typeof(Code))]
            [Binding("LinkType")]
            [Cardinality(Min = 1, Max = 1)]
            [DataMember]
            public Code<LinkType> TypeElement
            {
                get
                {
                    return _TypeElement;
                }
                set
                {
                    _TypeElement = value;
                    OnPropertyChanged("TypeElement");
                }
            }

            /// <summary>
            /// replaced-by | replaces | refer | seealso
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [IgnoreDataMember]
            public LinkType? Type
            {
                get
                {
                    if (TypeElement == null)
                    {
                        return null;
                    }

                    return TypeElement.Value;
                }
                set
                {
                    if (!value.HasValue)
                    {
                        TypeElement = null;
                    }
                    else
                    {
                        TypeElement = new Code<LinkType>(value);
                    }

                    OnPropertyChanged("Type");
                }
            }

            [IgnoreDataMember]
            public override IEnumerable<Base> Children
            {
                get
                {
                    foreach (Base child in base.Children)
                    {
                        yield return child;
                    }

                    if (Other != null)
                    {
                        yield return Other;
                    }

                    if (TypeElement != null)
                    {
                        yield return TypeElement;
                    }
                }
            }

            [IgnoreDataMember]
            public override IEnumerable<ElementValue> NamedChildren
            {
                get
                {
                    foreach (ElementValue namedChild in base.NamedChildren)
                    {
                        yield return namedChild;
                    }

                    if (Other != null)
                    {
                        yield return new ElementValue("other", Other);
                    }

                    if (TypeElement != null)
                    {
                        yield return new ElementValue("type", TypeElement);
                    }
                }
            }

            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                LinkComponent linkComponent = other as LinkComponent;
                if (linkComponent == null)
                {
                    throw new ArgumentException("Can only copy to an object of the same type", "other");
                }

                base.CopyTo((IDeepCopyable)linkComponent);
                if (Other != null)
                {
                    linkComponent.Other = (ResourceReference)Other.DeepCopy();
                }

                if (TypeElement != null)
                {
                    linkComponent.TypeElement = (Code<LinkType>)TypeElement.DeepCopy();
                }

                return linkComponent;
            }

            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new LinkComponent());
            }

            /// <inheritdoc />
            public override bool Matches(IDeepComparable other)
            {
                LinkComponent linkComponent = other as LinkComponent;
                if (linkComponent == null)
                {
                    return false;
                }

                if (!base.Matches((IDeepComparable)linkComponent))
                {
                    return false;
                }

                if (!DeepComparable.Matches((IDeepComparable)Other, (IDeepComparable)linkComponent.Other))
                {
                    return false;
                }

                if (!DeepComparable.Matches((IDeepComparable)TypeElement, (IDeepComparable)linkComponent.TypeElement))
                {
                    return false;
                }

                return true;
            }

            public override bool IsExactly(IDeepComparable other)
            {
                LinkComponent linkComponent = other as LinkComponent;
                if (linkComponent == null)
                {
                    return false;
                }

                if (!base.IsExactly((IDeepComparable)linkComponent))
                {
                    return false;
                }

                if (!DeepComparable.IsExactly((IDeepComparable)Other, (IDeepComparable)linkComponent.Other))
                {
                    return false;
                }

                if (!DeepComparable.IsExactly((IDeepComparable)TypeElement, (IDeepComparable)linkComponent.TypeElement))
                {
                    return false;
                }

                return true;
            }

            protected override bool TryGetValue(string key, out object value)
            {
                if (!(key == "other"))
                {
                    if (key == "type")
                    {
                        value = TypeElement;
                        return TypeElement != null;
                    }

                    return base.TryGetValue(key, out value);
                }

                value = Other;
                return Other != null;
            }

            protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
            {
                foreach (KeyValuePair<string, object> elementPair in base.GetElementPairs())
                {
                    yield return elementPair;
                }

                if (Other != null)
                {
                    yield return new KeyValuePair<string, object>("other", Other);
                }

                if (TypeElement != null)
                {
                    yield return new KeyValuePair<string, object>("type", TypeElement);
                }
            }
        }

        private List<Identifier> _Identifier;

        private FhirBoolean _ActiveElement;

        private List<HumanName> _Name;

        private List<ContactPoint> _Telecom;

        private Code<AdministrativeGender> _GenderElement;

        private Date _BirthDateElement;

        private DataType _Deceased;

        private List<Address> _Address;

        private CodeableConcept _MaritalStatus;

        private DataType _MultipleBirth;

        private List<Attachment> _Photo;

        private List<ContactComponent> _Contact;

        private List<CommunicationComponent> _Communication;

        private List<ResourceReference> _GeneralPractitioner;

        private ResourceReference _ManagingOrganization;

        private List<LinkComponent> _Link;

        /// <summary>
        /// FHIR Type Name
        /// </summary>
        public override string TypeName => "Patient";

        /// <summary>
        /// An identifier for this patient
        /// </summary>
        [FhirElement("identifier", InSummary = true, Order = 90, FiveWs = "FiveWs.identifier")]
        [Cardinality(Min = 0, Max = -1)]
        [DataMember]
        public List<Identifier> Identifier
        {
            get
            {
                if (_Identifier == null)
                {
                    _Identifier = new List<Identifier>();
                }

                return _Identifier;
            }
            set
            {
                _Identifier = value;
                OnPropertyChanged("Identifier");
            }
        }

        /// <summary>
        /// Whether this patient's record is in active use
        /// </summary>
        [FhirElement("active", InSummary = true, IsModifier = true, Order = 100, FiveWs = "FiveWs.status")]
        [DataMember]
        public FhirBoolean ActiveElement
        {
            get
            {
                return _ActiveElement;
            }
            set
            {
                _ActiveElement = value;
                OnPropertyChanged("ActiveElement");
            }
        }

        /// <summary>
        /// Whether this patient's record is in active use
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [IgnoreDataMember]
        public bool? Active
        {
            get
            {
                if (ActiveElement == null)
                {
                    return null;
                }

                return ActiveElement.Value;
            }
            set
            {
                if (!value.HasValue)
                {
                    ActiveElement = null;
                }
                else
                {
                    ActiveElement = new FhirBoolean(value);
                }

                OnPropertyChanged("Active");
            }
        }

        /// <summary>
        /// A name associated with the patient
        /// </summary>
        [FhirElement("name", InSummary = true, Order = 110)]
        [Cardinality(Min = 0, Max = -1)]
        [DataMember]
        public List<HumanName> Name
        {
            get
            {
                if (_Name == null)
                {
                    _Name = new List<HumanName>();
                }

                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// A contact detail for the individual
        /// </summary>
        [FhirElement("telecom", InSummary = true, Order = 120)]
        [Cardinality(Min = 0, Max = -1)]
        [DataMember]
        public List<ContactPoint> Telecom
        {
            get
            {
                if (_Telecom == null)
                {
                    _Telecom = new List<ContactPoint>();
                }

                return _Telecom;
            }
            set
            {
                _Telecom = value;
                OnPropertyChanged("Telecom");
            }
        }

        /// <summary>
        /// male | female | other | unknown
        /// </summary>
        [FhirElement("gender", InSummary = true, Order = 130)]
        [DeclaredType(Type = typeof(Code))]
        [Binding("AdministrativeGender")]
        [DataMember]
        public Code<AdministrativeGender> GenderElement
        {
            get
            {
                return _GenderElement;
            }
            set
            {
                _GenderElement = value;
                OnPropertyChanged("GenderElement");
            }
        }

        /// <summary>
        /// male | female | other | unknown
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [IgnoreDataMember]
        public AdministrativeGender? Gender
        {
            get
            {
                if (GenderElement == null)
                {
                    return null;
                }

                return GenderElement.Value;
            }
            set
            {
                if (!value.HasValue)
                {
                    GenderElement = null;
                }
                else
                {
                    GenderElement = new Code<AdministrativeGender>(value);
                }

                OnPropertyChanged("Gender");
            }
        }

        /// <summary>
        /// The date of birth for the individual
        /// </summary>
        [FhirElement("birthDate", InSummary = true, Order = 140)]
        [DataMember]
        public Date BirthDateElement
        {
            get
            {
                return _BirthDateElement;
            }
            set
            {
                _BirthDateElement = value;
                OnPropertyChanged("BirthDateElement");
            }
        }

        /// <summary>
        /// The date of birth for the individual
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [IgnoreDataMember]
        public string BirthDate
        {
            get
            {
                if (!(BirthDateElement != null))
                {
                    return null;
                }

                return BirthDateElement.Value;
            }
            set
            {
                if (value == null)
                {
                    BirthDateElement = null;
                }
                else
                {
                    BirthDateElement = new Date(value);
                }

                OnPropertyChanged("BirthDate");
            }
        }

        /// <summary>
        /// Indicates if the individual is deceased or not
        /// </summary>
        [FhirElement("deceased", InSummary = true, IsModifier = true, Order = 150, Choice = ChoiceType.DatatypeChoice)]
        [CLSCompliant(false)]
        [AllowedTypes(new Type[]
        {
            typeof(FhirBoolean),
            typeof(FhirDateTime)
        })]
        [DataMember]
        public DataType Deceased
        {
            get
            {
                return _Deceased;
            }
            set
            {
                _Deceased = value;
                OnPropertyChanged("Deceased");
            }
        }

        /// <summary>
        /// An address for the individual
        /// </summary>
        [FhirElement("address", InSummary = true, Order = 160)]
        [Cardinality(Min = 0, Max = -1)]
        [DataMember]
        public List<Address> Address
        {
            get
            {
                if (_Address == null)
                {
                    _Address = new List<Address>();
                }

                return _Address;
            }
            set
            {
                _Address = value;
                OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// Marital (civil) status of a patient
        /// </summary>
        [FhirElement("maritalStatus", Order = 170)]
        [Binding("MaritalStatus")]
        [DataMember]
        public CodeableConcept MaritalStatus
        {
            get
            {
                return _MaritalStatus;
            }
            set
            {
                _MaritalStatus = value;
                OnPropertyChanged("MaritalStatus");
            }
        }

        /// <summary>
        /// Whether patient is part of a multiple birth
        /// </summary>
        [FhirElement("multipleBirth", Order = 180, Choice = ChoiceType.DatatypeChoice)]
        [CLSCompliant(false)]
        [AllowedTypes(new Type[]
        {
            typeof(FhirBoolean),
            typeof(Integer)
        })]
        [DataMember]
        public DataType MultipleBirth
        {
            get
            {
                return _MultipleBirth;
            }
            set
            {
                _MultipleBirth = value;
                OnPropertyChanged("MultipleBirth");
            }
        }

        /// <summary>
        /// Image of the patient
        /// </summary>
        [FhirElement("photo", Order = 190)]
        [Cardinality(Min = 0, Max = -1)]
        [DataMember]
        public List<Attachment> Photo
        {
            get
            {
                if (_Photo == null)
                {
                    _Photo = new List<Attachment>();
                }

                return _Photo;
            }
            set
            {
                _Photo = value;
                OnPropertyChanged("Photo");
            }
        }

        /// <summary>
        /// A contact party (e.g. guardian, partner, friend) for the patient
        /// </summary>
        [FhirElement("contact", Order = 200)]
        [Cardinality(Min = 0, Max = -1)]
        [DataMember]
        public List<ContactComponent> Contact
        {
            get
            {
                if (_Contact == null)
                {
                    _Contact = new List<ContactComponent>();
                }

                return _Contact;
            }
            set
            {
                _Contact = value;
                OnPropertyChanged("Contact");
            }
        }

        /// <summary>
        /// A language which may be used to communicate with the patient about his or her health
        /// </summary>
        [FhirElement("communication", Order = 210)]
        [Cardinality(Min = 0, Max = -1)]
        [DataMember]
        public List<CommunicationComponent> Communication
        {
            get
            {
                if (_Communication == null)
                {
                    _Communication = new List<CommunicationComponent>();
                }

                return _Communication;
            }
            set
            {
                _Communication = value;
                OnPropertyChanged("Communication");
            }
        }

        /// <summary>
        /// Patient's nominated primary care provider
        /// </summary>
        [FhirElement("generalPractitioner", Order = 220)]
        [CLSCompliant(false)]
        [References(new string[] { "Organization", "Practitioner", "PractitionerRole" })]
        [Cardinality(Min = 0, Max = -1)]
        [DataMember]
        public List<ResourceReference> GeneralPractitioner
        {
            get
            {
                if (_GeneralPractitioner == null)
                {
                    _GeneralPractitioner = new List<ResourceReference>();
                }

                return _GeneralPractitioner;
            }
            set
            {
                _GeneralPractitioner = value;
                OnPropertyChanged("GeneralPractitioner");
            }
        }

        /// <summary>
        /// Organization that is the custodian of the patient record
        /// </summary>
        [FhirElement("managingOrganization", InSummary = true, Order = 230)]
        [CLSCompliant(false)]
        [References(new string[] { "Organization" })]
        [DataMember]
        public ResourceReference ManagingOrganization
        {
            get
            {
                return _ManagingOrganization;
            }
            set
            {
                _ManagingOrganization = value;
                OnPropertyChanged("ManagingOrganization");
            }
        }

        /// <summary>
        /// Link to another patient resource that concerns the same actual person
        /// </summary>
        [FhirElement("link", InSummary = true, IsModifier = true, Order = 240)]
        [Cardinality(Min = 0, Max = -1)]
        [DataMember]
        public List<LinkComponent> Link
        {
            get
            {
                if (_Link == null)
                {
                    _Link = new List<LinkComponent>();
                }

                return _Link;
            }
            set
            {
                _Link = value;
                OnPropertyChanged("Link");
            }
        }

        List<Identifier> IIdentifiable<List<Identifier>>.Identifier
        {
            get
            {
                return Identifier;
            }
            set
            {
                Identifier = value;
            }
        }

        Date IPatient.BirthDate => BirthDateElement;

        [IgnoreDataMember]
        public override IEnumerable<Base> Children
        {
            get
            {
                foreach (Base child in base.Children)
                {
                    yield return child;
                }

                foreach (Identifier item in Identifier)
                {
                    if (item != null)
                    {
                        yield return item;
                    }
                }

                if (ActiveElement != null)
                {
                    yield return ActiveElement;
                }

                foreach (HumanName item2 in Name)
                {
                    if (item2 != null)
                    {
                        yield return item2;
                    }
                }

                foreach (ContactPoint item3 in Telecom)
                {
                    if (item3 != null)
                    {
                        yield return item3;
                    }
                }

                if (GenderElement != null)
                {
                    yield return GenderElement;
                }

                if (BirthDateElement != null)
                {
                    yield return BirthDateElement;
                }

                if (Deceased != null)
                {
                    yield return Deceased;
                }

                foreach (Address item4 in Address)
                {
                    if (item4 != null)
                    {
                        yield return item4;
                    }
                }

                if (MaritalStatus != null)
                {
                    yield return MaritalStatus;
                }

                if (MultipleBirth != null)
                {
                    yield return MultipleBirth;
                }

                foreach (Attachment item5 in Photo)
                {
                    if (item5 != null)
                    {
                        yield return item5;
                    }
                }

                foreach (ContactComponent item6 in Contact)
                {
                    if (item6 != null)
                    {
                        yield return item6;
                    }
                }

                foreach (CommunicationComponent item7 in Communication)
                {
                    if (item7 != null)
                    {
                        yield return item7;
                    }
                }

                foreach (ResourceReference item8 in GeneralPractitioner)
                {
                    if (item8 != null)
                    {
                        yield return item8;
                    }
                }

                if (ManagingOrganization != null)
                {
                    yield return ManagingOrganization;
                }

                foreach (LinkComponent item9 in Link)
                {
                    if (item9 != null)
                    {
                        yield return item9;
                    }
                }
            }
        }

        [IgnoreDataMember]
        public override IEnumerable<ElementValue> NamedChildren
        {
            get
            {
                foreach (ElementValue namedChild in base.NamedChildren)
                {
                    yield return namedChild;
                }

                foreach (Identifier item in Identifier)
                {
                    if (item != null)
                    {
                        yield return new ElementValue("identifier", item);
                    }
                }

                if (ActiveElement != null)
                {
                    yield return new ElementValue("active", ActiveElement);
                }

                foreach (HumanName item2 in Name)
                {
                    if (item2 != null)
                    {
                        yield return new ElementValue("name", item2);
                    }
                }

                foreach (ContactPoint item3 in Telecom)
                {
                    if (item3 != null)
                    {
                        yield return new ElementValue("telecom", item3);
                    }
                }

                if (GenderElement != null)
                {
                    yield return new ElementValue("gender", GenderElement);
                }

                if (BirthDateElement != null)
                {
                    yield return new ElementValue("birthDate", BirthDateElement);
                }

                if (Deceased != null)
                {
                    yield return new ElementValue("deceased", Deceased);
                }

                foreach (Address item4 in Address)
                {
                    if (item4 != null)
                    {
                        yield return new ElementValue("address", item4);
                    }
                }

                if (MaritalStatus != null)
                {
                    yield return new ElementValue("maritalStatus", MaritalStatus);
                }

                if (MultipleBirth != null)
                {
                    yield return new ElementValue("multipleBirth", MultipleBirth);
                }

                foreach (Attachment item5 in Photo)
                {
                    if (item5 != null)
                    {
                        yield return new ElementValue("photo", item5);
                    }
                }

                foreach (ContactComponent item6 in Contact)
                {
                    if (item6 != null)
                    {
                        yield return new ElementValue("contact", item6);
                    }
                }

                foreach (CommunicationComponent item7 in Communication)
                {
                    if (item7 != null)
                    {
                        yield return new ElementValue("communication", item7);
                    }
                }

                foreach (ResourceReference item8 in GeneralPractitioner)
                {
                    if (item8 != null)
                    {
                        yield return new ElementValue("generalPractitioner", item8);
                    }
                }

                if (ManagingOrganization != null)
                {
                    yield return new ElementValue("managingOrganization", ManagingOrganization);
                }

                foreach (LinkComponent item9 in Link)
                {
                    if (item9 != null)
                    {
                        yield return new ElementValue("link", item9);
                    }
                }
            }
        }

        public override IDeepCopyable CopyTo(IDeepCopyable other)
        {
            Patient patient = other as Patient;
            if (patient == null)
            {
                throw new ArgumentException("Can only copy to an object of the same type", "other");
            }

            base.CopyTo((IDeepCopyable)patient);
            if (Identifier != null)
            {
                patient.Identifier = new List<Identifier>(Identifier.DeepCopy());
            }

            if (ActiveElement != null)
            {
                patient.ActiveElement = (FhirBoolean)ActiveElement.DeepCopy();
            }

            if (Name != null)
            {
                patient.Name = new List<HumanName>(Name.DeepCopy());
            }

            if (Telecom != null)
            {
                patient.Telecom = new List<ContactPoint>(Telecom.DeepCopy());
            }

            if (GenderElement != null)
            {
                patient.GenderElement = (Code<AdministrativeGender>)GenderElement.DeepCopy();
            }

            if (BirthDateElement != null)
            {
                patient.BirthDateElement = (Date)BirthDateElement.DeepCopy();
            }

            if (Deceased != null)
            {
                patient.Deceased = (DataType)Deceased.DeepCopy();
            }

            if (Address != null)
            {
                patient.Address = new List<Address>(Address.DeepCopy());
            }

            if (MaritalStatus != null)
            {
                patient.MaritalStatus = (CodeableConcept)MaritalStatus.DeepCopy();
            }

            if (MultipleBirth != null)
            {
                patient.MultipleBirth = (DataType)MultipleBirth.DeepCopy();
            }

            if (Photo != null)
            {
                patient.Photo = new List<Attachment>(Photo.DeepCopy());
            }

            if (Contact != null)
            {
                patient.Contact = new List<ContactComponent>(Contact.DeepCopy());
            }

            if (Communication != null)
            {
                patient.Communication = new List<CommunicationComponent>(Communication.DeepCopy());
            }

            if (GeneralPractitioner != null)
            {
                patient.GeneralPractitioner = new List<ResourceReference>(GeneralPractitioner.DeepCopy());
            }

            if (ManagingOrganization != null)
            {
                patient.ManagingOrganization = (ResourceReference)ManagingOrganization.DeepCopy();
            }

            if (Link != null)
            {
                patient.Link = new List<LinkComponent>(Link.DeepCopy());
            }

            return patient;
        }

        public override IDeepCopyable DeepCopy()
        {
            return CopyTo(new Patient());
        }

        /// <inheritdoc />
        public override bool Matches(IDeepComparable other)
        {
            Patient patient = other as Patient;
            if (patient == null)
            {
                return false;
            }

            if (!base.Matches((IDeepComparable)patient))
            {
                return false;
            }

            if (!Identifier.Matches(patient.Identifier))
            {
                return false;
            }

            if (!DeepComparable.Matches((IDeepComparable)ActiveElement, (IDeepComparable)patient.ActiveElement))
            {
                return false;
            }

            if (!Name.Matches(patient.Name))
            {
                return false;
            }

            if (!Telecom.Matches(patient.Telecom))
            {
                return false;
            }

            if (!DeepComparable.Matches((IDeepComparable)GenderElement, (IDeepComparable)patient.GenderElement))
            {
                return false;
            }

            if (!DeepComparable.Matches((IDeepComparable)BirthDateElement, (IDeepComparable)patient.BirthDateElement))
            {
                return false;
            }

            if (!DeepComparable.Matches((IDeepComparable)Deceased, (IDeepComparable)patient.Deceased))
            {
                return false;
            }

            if (!Address.Matches(patient.Address))
            {
                return false;
            }

            if (!DeepComparable.Matches((IDeepComparable)MaritalStatus, (IDeepComparable)patient.MaritalStatus))
            {
                return false;
            }

            if (!DeepComparable.Matches((IDeepComparable)MultipleBirth, (IDeepComparable)patient.MultipleBirth))
            {
                return false;
            }

            if (!Photo.Matches(patient.Photo))
            {
                return false;
            }

            if (!Contact.Matches(patient.Contact))
            {
                return false;
            }

            if (!Communication.Matches(patient.Communication))
            {
                return false;
            }

            if (!GeneralPractitioner.Matches(patient.GeneralPractitioner))
            {
                return false;
            }

            if (!DeepComparable.Matches((IDeepComparable)ManagingOrganization, (IDeepComparable)patient.ManagingOrganization))
            {
                return false;
            }

            if (!Link.Matches(patient.Link))
            {
                return false;
            }

            return true;
        }

        public override bool IsExactly(IDeepComparable other)
        {
            Patient patient = other as Patient;
            if (patient == null)
            {
                return false;
            }

            if (!base.IsExactly((IDeepComparable)patient))
            {
                return false;
            }

            if (!Identifier.IsExactly(patient.Identifier))
            {
                return false;
            }

            if (!DeepComparable.IsExactly((IDeepComparable)ActiveElement, (IDeepComparable)patient.ActiveElement))
            {
                return false;
            }

            if (!Name.IsExactly(patient.Name))
            {
                return false;
            }

            if (!Telecom.IsExactly(patient.Telecom))
            {
                return false;
            }

            if (!DeepComparable.IsExactly((IDeepComparable)GenderElement, (IDeepComparable)patient.GenderElement))
            {
                return false;
            }

            if (!DeepComparable.IsExactly((IDeepComparable)BirthDateElement, (IDeepComparable)patient.BirthDateElement))
            {
                return false;
            }

            if (!DeepComparable.IsExactly((IDeepComparable)Deceased, (IDeepComparable)patient.Deceased))
            {
                return false;
            }

            if (!Address.IsExactly(patient.Address))
            {
                return false;
            }

            if (!DeepComparable.IsExactly((IDeepComparable)MaritalStatus, (IDeepComparable)patient.MaritalStatus))
            {
                return false;
            }

            if (!DeepComparable.IsExactly((IDeepComparable)MultipleBirth, (IDeepComparable)patient.MultipleBirth))
            {
                return false;
            }

            if (!Photo.IsExactly(patient.Photo))
            {
                return false;
            }

            if (!Contact.IsExactly(patient.Contact))
            {
                return false;
            }

            if (!Communication.IsExactly(patient.Communication))
            {
                return false;
            }

            if (!GeneralPractitioner.IsExactly(patient.GeneralPractitioner))
            {
                return false;
            }

            if (!DeepComparable.IsExactly((IDeepComparable)ManagingOrganization, (IDeepComparable)patient.ManagingOrganization))
            {
                return false;
            }

            if (!Link.IsExactly(patient.Link))
            {
                return false;
            }

            return true;
        }

        protected override bool TryGetValue(string key, out object value)
        {
            if (key != null)
            {
                switch (key.Length)
                {
                    case 6:
                        switch (key[0])
                        {
                            case 'a':
                                if (!(key == "active"))
                                {
                                    break;
                                }

                                value = ActiveElement;
                                return ActiveElement != null;
                            case 'g':
                                if (!(key == "gender"))
                                {
                                    break;
                                }

                                value = GenderElement;
                                return GenderElement != null;
                        }

                        break;
                    case 4:
                        switch (key[0])
                        {
                            case 'n':
                                if (!(key == "name"))
                                {
                                    break;
                                }

                                value = Name;
                                return Name?.Any() ?? false;
                            case 'l':
                                if (!(key == "link"))
                                {
                                    break;
                                }

                                value = Link;
                                return Link?.Any() ?? false;
                        }

                        break;
                    case 7:
                        switch (key[0])
                        {
                            case 't':
                                if (!(key == "telecom"))
                                {
                                    break;
                                }

                                value = Telecom;
                                return Telecom?.Any() ?? false;
                            case 'a':
                                if (!(key == "address"))
                                {
                                    break;
                                }

                                value = Address;
                                return Address?.Any() ?? false;
                            case 'c':
                                if (!(key == "contact"))
                                {
                                    break;
                                }

                                value = Contact;
                                return Contact?.Any() ?? false;
                        }

                        break;
                    case 13:
                        switch (key[1])
                        {
                            case 'a':
                                if (!(key == "maritalStatus"))
                                {
                                    break;
                                }

                                value = MaritalStatus;
                                return MaritalStatus != null;
                            case 'u':
                                if (!(key == "multipleBirth"))
                                {
                                    break;
                                }

                                value = MultipleBirth;
                                return MultipleBirth != null;
                            case 'o':
                                if (!(key == "communication"))
                                {
                                    break;
                                }

                                value = Communication;
                                return Communication?.Any() ?? false;
                        }

                        break;
                    case 10:
                        if (!(key == "identifier"))
                        {
                            break;
                        }

                        value = Identifier;
                        return Identifier?.Any() ?? false;
                    case 9:
                        if (!(key == "birthDate"))
                        {
                            break;
                        }

                        value = BirthDateElement;
                        return (object)BirthDateElement != null;
                    case 8:
                        if (!(key == "deceased"))
                        {
                            break;
                        }

                        value = Deceased;
                        return Deceased != null;
                    case 5:
                        if (!(key == "photo"))
                        {
                            break;
                        }

                        value = Photo;
                        return Photo?.Any() ?? false;
                    case 19:
                        if (!(key == "generalPractitioner"))
                        {
                            break;
                        }

                        value = GeneralPractitioner;
                        return GeneralPractitioner?.Any() ?? false;
                    case 20:
                        if (!(key == "managingOrganization"))
                        {
                            break;
                        }

                        value = ManagingOrganization;
                        return ManagingOrganization != null;
                }
            }

            return base.TryGetValue(key, out value);
        }

        protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
        {
            foreach (KeyValuePair<string, object> elementPair in base.GetElementPairs())
            {
                yield return elementPair;
            }

            if (Identifier?.Any() ?? false)
            {
                yield return new KeyValuePair<string, object>("identifier", Identifier);
            }

            if (ActiveElement != null)
            {
                yield return new KeyValuePair<string, object>("active", ActiveElement);
            }

            if (Name?.Any() ?? false)
            {
                yield return new KeyValuePair<string, object>("name", Name);
            }

            if (Telecom?.Any() ?? false)
            {
                yield return new KeyValuePair<string, object>("telecom", Telecom);
            }

            if (GenderElement != null)
            {
                yield return new KeyValuePair<string, object>("gender", GenderElement);
            }

            if ((object)BirthDateElement != null)
            {
                yield return new KeyValuePair<string, object>("birthDate", BirthDateElement);
            }

            if (Deceased != null)
            {
                yield return new KeyValuePair<string, object>("deceased", Deceased);
            }

            if (Address?.Any() ?? false)
            {
                yield return new KeyValuePair<string, object>("address", Address);
            }

            if (MaritalStatus != null)
            {
                yield return new KeyValuePair<string, object>("maritalStatus", MaritalStatus);
            }

            if (MultipleBirth != null)
            {
                yield return new KeyValuePair<string, object>("multipleBirth", MultipleBirth);
            }

            if (Photo?.Any() ?? false)
            {
                yield return new KeyValuePair<string, object>("photo", Photo);
            }

            if (Contact?.Any() ?? false)
            {
                yield return new KeyValuePair<string, object>("contact", Contact);
            }

            if (Communication?.Any() ?? false)
            {
                yield return new KeyValuePair<string, object>("communication", Communication);
            }

            if (GeneralPractitioner?.Any() ?? false)
            {
                yield return new KeyValuePair<string, object>("generalPractitioner", GeneralPractitioner);
            }

            if (ManagingOrganization != null)
            {
                yield return new KeyValuePair<string, object>("managingOrganization", ManagingOrganization);
            }

            if (Link?.Any() ?? false)
            {
                yield return new KeyValuePair<string, object>("link", Link);
            }
        }
    }
}
#if false // Decompilation log
'168' items in cache
------------------
Resolve: 'System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
WARN: Version mismatch. Expected: '6.0.0.0', Got: '7.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.9\ref\net7.0\System.Runtime.dll'
------------------
Resolve: 'Hl7.Fhir.Base, Version=5.3.0.0, Culture=neutral, PublicKeyToken=d706911480550fc3'
Found single assembly: 'Hl7.Fhir.Base, Version=5.3.0.0, Culture=neutral, PublicKeyToken=d706911480550fc3'
Load from: 'C:\Users\Dell\.nuget\packages\hl7.fhir.base\5.3.0\lib\net6.0\Hl7.Fhir.Base.dll'
------------------
Resolve: 'Hl7.Fhir.Conformance, Version=5.3.0.0, Culture=neutral, PublicKeyToken=d706911480550fc3'
Found single assembly: 'Hl7.Fhir.Conformance, Version=5.3.0.0, Culture=neutral, PublicKeyToken=d706911480550fc3'
Load from: 'C:\Users\Dell\.nuget\packages\hl7.fhir.conformance\5.3.0\lib\net6.0\Hl7.Fhir.Conformance.dll'
------------------
Resolve: 'Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed'
Found single assembly: 'Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed'
Load from: 'C:\Users\Dell\.nuget\packages\newtonsoft.json\13.0.3\lib\net6.0\Newtonsoft.Json.dll'
------------------
Resolve: 'System.Xml.ReaderWriter, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Xml.ReaderWriter, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
WARN: Version mismatch. Expected: '6.0.0.0', Got: '7.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.9\ref\net7.0\System.Xml.ReaderWriter.dll'
------------------
Resolve: 'System.Text.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Found single assembly: 'System.Text.Json, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
WARN: Version mismatch. Expected: '6.0.0.0', Got: '7.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.9\ref\net7.0\System.Text.Json.dll'
------------------
Resolve: 'System.Xml.XDocument, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Xml.XDocument, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
WARN: Version mismatch. Expected: '6.0.0.0', Got: '7.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.9\ref\net7.0\System.Xml.XDocument.dll'
------------------
Resolve: 'System.Net.Http, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Net.Http, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
WARN: Version mismatch. Expected: '6.0.0.0', Got: '7.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.9\ref\net7.0\System.Net.Http.dll'
------------------
Resolve: 'System.Runtime.Serialization.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Runtime.Serialization.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
WARN: Version mismatch. Expected: '6.0.0.0', Got: '7.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.9\ref\net7.0\System.Runtime.Serialization.Primitives.dll'
------------------
Resolve: 'System.Collections, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Collections, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
WARN: Version mismatch. Expected: '6.0.0.0', Got: '7.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.9\ref\net7.0\System.Collections.dll'
------------------
Resolve: 'System.Linq, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Linq, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
WARN: Version mismatch. Expected: '6.0.0.0', Got: '7.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.9\ref\net7.0\System.Linq.dll'
------------------
Resolve: 'System.Net.Primitives, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Net.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
WARN: Version mismatch. Expected: '6.0.0.0', Got: '7.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.9\ref\net7.0\System.Net.Primitives.dll'
------------------
Resolve: 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.9\ref\net7.0\System.Runtime.dll'
#endif
