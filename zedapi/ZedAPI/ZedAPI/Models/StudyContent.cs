using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZedAPI.Models
{
    public class StudyContent
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid GUID { get; set; }
        public string SpecificCharacterSet { get; set; }
        public string StudyInstanceUid { get; set; }
        public string PatientsName { get; set; }
        public string PatientId { get; set; }
        public string IssuerOfPatientId { get; set; }
        public string GlobalPatientId { get; set; }
        public string PatientsBirthDate { get; set; }
        public string PatientsAge { get; set; }
        public string PatientSex { get; set; }
        public string StudyDate { get; set; }
        public string StudyTime { get; set; }
        public string AccessionNumber { get; set; }
        public string StudyId { get; set; }
        public string StudyDescription { get; set; }
        public string ReferringPhysiciansName { get; set; }
        public string ReferringPhysiciansId { get; set; }
        public int NumberOfStudyRelatedSeries { get; set; }
        public int NumberOfStudyRelatedInstances { get; set; }
        public bool UserRequested { get; set; }
        public string FilmBagGuid { get; set; }
        public bool IsRemote { get; set; }
        public int StudyQueueStatusEnum { get; set; }
        public string Modality { get; set; }
        public string ReportGuid { get; set; }
        public int StudyStatusEnum { get; set; }
        public int NumberOfRelatedStudies { get; set; }
        public DateTime LastImageReceived { get; set; }
        public int StudySize { get; set; }
        public bool NoImage { get; set; }
        public bool Locked { get; set; }
        public string LockedAt { get; set; }
        public string LockedUntil { get; set; }
        public int StudyImportTypeEnum { get; set; }
        public bool Hidden { get; set; }
        public string HiddenAt { get; set; }
        public string HiddenUntil { get; set; }
        public bool HasAttachments { get; set; }
        public string OrganisationSiteId { get; set; }
        public string OrganisationSite { get; set; }
        public int NumberOfAttachments { get; set; }
        public string FusionEventId { get; set; }
        public DateTime InsertDateTime { get; set; }

    }
}
