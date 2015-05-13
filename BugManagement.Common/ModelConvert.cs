using BugManagement.ApplicationDto;
using BugManagement.DomainDto;
using BugManagement.DomainModel;
using BugManagement.ViewModel;

namespace BugManagement.Common
{
    public static class ModelConvert
    {
        public static ProjectListViewModel.Project ToProjectViewModel(this ProjectApplicationDto dto)
        {
            return new ProjectListViewModel.Project()
                   {
                       Id = dto.Id,
                       Name = dto.Name
                   };
        }

        public static ProjectApplicationDto ToProjectApplicationDto(this ProjectDomainDto dto)
        {
            return new ProjectApplicationDto()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static ProjectDomainDto ToProjectDomainDto(this Project project)
        {
            return new ProjectDomainDto()
            {
                Id = project.Id,
                Name = project.Name
            };
        }
    }
}
