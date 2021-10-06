using Application.Data.Models;
using Application.Models;
using Profile = AutoMapper.Profile;
/**
 * 
 * name         :   AutomapperProfile.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Frameworks
{
    public class AutomapperProfile : AutoMapper.Profile
    {
        public AutomapperProfile()
        {
            CreateMap<GuardianViewModel, Guardian>();
            CreateMap<DoctorViewModel, Doctor>();
            CreateMap<GuardianViewModel, Guardian>();
            CreateMap<HealthIssueViewModel, HealthIssue>();
            CreateMap<KinViewModel, Kin>();
            CreateMap<Kin, KinViewModel>();

            CreateMap<Address, AddressViewModel>();
            CreateMap<AddressViewModel, Address>();

            CreateMap<MemberViewModel, Member>()
                .ForMember(d => d.Player, o => o.Condition(s => s.Type != MemberType.Member));
            CreateMap<Member, MemberViewModel>().ForMember(d => d.Player, o => o.NullSubstitute(new Player()));

            CreateMap<PlayerViewModel, Player>();
            CreateMap<Player, PlayerViewModel>().ForMember(d => d.Junior, o => o.NullSubstitute(new Junior()));
            CreateMap<JuniorViewModel, Junior>();
            CreateMap<Junior, JuniorViewModel>();
            CreateMap<SeniorViewModel, Senior>();
            CreateMap<Senior, SeniorViewModel>();


            CreateMap<TrainingViewModel, Training>();
            CreateMap<Training, TrainingViewModel>();
            CreateMap<ActivitiesViewModel, Activities>();
            CreateMap<Activities, ActivitiesViewModel>();
            CreateMap<AttendanceViewModel, Attendance>();
            CreateMap<Attendance, AttendanceViewModel>();

            CreateMap<Profile, ProfileViewModel>();
            CreateMap<ProfileViewModel, Profile>();
            CreateMap<Skill, SkillViewModel>();
            CreateMap<SkillViewModel, Skill>();

            CreateMap<Member, MemberShortViewModel>();
            CreateMap<MemberShortViewModel, Member>();
            
            CreateMap<Game, GameViewModel>();
            CreateMap<GameViewModel, Game>();
            
            CreateMap<Scores, ScoreViewModel>();
            CreateMap<ScoreViewModel, Scores>();
        }


        public static void Run()
        {
            AutoMapper.Mapper.Initialize(m => m.AddProfile<AutomapperProfile>());
        }
    }
}