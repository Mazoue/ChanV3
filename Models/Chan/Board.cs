using Newtonsoft.Json;

namespace Models.Chan
{
    public class Board
    {
        [JsonProperty("board")]
        public string board { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("ws_board")]
        public int WsBoard { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }

        [JsonProperty("max_filesize")]
        public int MaxFilesize { get; set; }

        [JsonProperty("max_webm_filesize")]
        public int MaxWebmFilesize { get; set; }

        [JsonProperty("max_comment_chars")]
        public int MaxCommentChars { get; set; }

        [JsonProperty("max_webm_duration")]
        public int MaxWebmDuration { get; set; }

        [JsonProperty("bump_limit")]
        public int BumpLimit { get; set; }

        [JsonProperty("image_limit")]
        public int ImageLimit { get; set; }

        [JsonProperty("cooldowns")]
        public Cooldowns Cooldowns { get; set; }

        [JsonProperty("meta_description")]
        public string MetaDescription { get; set; }

        [JsonProperty("is_archived")]
        public int IsArchived { get; set; }

        [JsonProperty("spoilers")]
        public int? Spoilers { get; set; }

        [JsonProperty("custom_spoilers")]
        public int? CustomSpoilers { get; set; }

        [JsonProperty("forced_anon")]
        public int? ForcedAnon { get; set; }

        [JsonProperty("user_ids")]
        public int? UserIds { get; set; }

        [JsonProperty("country_flags")]
        public int? CountryFlags { get; set; }

        [JsonProperty("code_tags")]
        public int? CodeTags { get; set; }

        [JsonProperty("webm_audio")]
        public int? WebmAudio { get; set; }

        [JsonProperty("min_image_width")]
        public int? MinImageWidth { get; set; }

        [JsonProperty("min_image_height")]
        public int? MinImageHeight { get; set; }

        [JsonProperty("oekaki")]
        public int? Oekaki { get; set; }

        [JsonProperty("sjis_tags")]
        public int? SjisTags { get; set; }

        [JsonProperty("board_flags")]
        public BoardFlags BoardFlags { get; set; }

        [JsonProperty("text_only")]
        public int? TextOnly { get; set; }

        [JsonProperty("require_subject")]
        public int? RequireSubject { get; set; }
        public bool Checked { get; set; }
    }
}
