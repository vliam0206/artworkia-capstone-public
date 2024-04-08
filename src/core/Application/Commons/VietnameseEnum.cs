using Domain.Enums;

namespace Application.Commons;

public static class VietnameseEnum
{
    public static readonly Dictionary<ProposalAssetEnum, string> PROPOSALASSET_ENUM_VN = new()
    {
        { ProposalAssetEnum.Concept, "phác thảo" },
        { ProposalAssetEnum.Final, "cuối cùng" },
        { ProposalAssetEnum.Revision, "sửa đổi" }
    };

    public static readonly Dictionary<StateEnum, string> STATE_ENUM_VN = new()
    {
        { StateEnum.Waiting, "đang chờ" },
        { StateEnum.Accepted, "chấp nhận" },
        { StateEnum.Declined, "từ chối" },
        { StateEnum.Cancelled, "hủy bỏ" }
    };

    public static readonly Dictionary<ReportEntityEnum, string> REPORTENTITY_ENUM_VN = new()
    {
        { ReportEntityEnum.Comment, "bình luận" },
        { ReportEntityEnum.Account, "tài khoản" },
        { ReportEntityEnum.Artwork, "tác phẩm" }
    };

    public static readonly Dictionary<ProposalStateEnum, string> PROPOSALSTATE_ENUM_VN = new()
    {
        { ProposalStateEnum.Waiting, "đang chờ" },
        { ProposalStateEnum.Accepted, "chấp nhận" },
        { ProposalStateEnum.Declined, "từ chối" },
        { ProposalStateEnum.Cancelled, "hủy bỏ" },
        { ProposalStateEnum.InitPayment, "đã đặt cọc" },
        { ProposalStateEnum.Completed, "kết thúc" },
        { ProposalStateEnum.CompletePayment, "thanh toán toàn bộ" }
    };
}