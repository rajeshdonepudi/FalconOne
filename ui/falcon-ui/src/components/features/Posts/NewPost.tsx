import Stack from "@mui/material/Stack";
import Typography from "@mui/material/Typography";
import React, { useCallback, useEffect, useState } from "react";
import {
  Alert,
  Avatar,
  Button,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  Theme,
  createStyles,
} from "@mui/material";
import { makeStyles } from "@mui/styles";
import { MentionsInput, Mention } from "react-mentions";
import EmojiPicker from "emoji-picker-react";
import CloseIcon from "@mui/icons-material/Close";
import InsertEmoticonOutlinedIcon from "@mui/icons-material/InsertEmoticonOutlined";
import Tooltip from "@mui/material/Tooltip";
import AppImagePreviewer from "../../ui-components/AppImagePreviewer";
import AppCard from "../../ui-components/AppCard";
import AppImageUploader from "../../ui-components/AppImageUploader";
import AppImageList from "../../ui-components/AppImageList";
import AddReactionOutlinedIcon from "@mui/icons-material/AddReactionOutlined";
const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      "& .user": {
        color: theme.palette?.primary?.main,
      },
    },
  })
) as any;

const NewPost = (props: any) => {
  const [showPicker, setShowEmojiPicker] = useState(false);
  const classes = useStyles();

  const [user, setUser] = useState("");
  const [value, setValue] = useState<any>();

  const handleUserChange = (
    event: any,
    newValue: any,
    newPlainTextValue: any,
    mentions: any
  ) => {
    if (newValue) {
     
      setValue(newValue);
    }
  };

  const [postImages, setPostImages] = useState([]);
  const [imagePreviewerState, setImagePreviewerState] = useState(false);
  const emailRegex = /(([^\s@]+@[^\s@]+\.[^\s@]+))$/;
  const onChange = useCallback(
    (_: any, newValue: any) => setValue(newValue),
    [setValue]
  );

  const [emojis, setEmojis] = useState([]);

  useEffect(() => {
    fetch(
      "https://gist.githubusercontent.com/oliveratgithub/0bf11a9aff0d6da7b46f1490f86a71eb/raw/d8e4b78cfe66862cf3809443c1dba017f37b61db/emojis.json"
    )
      .then((response) => {
        return response.json();
      })
      .then((jsonData) => {
        setEmojis(jsonData.emojis);
      });
  }, []);

  const queryEmojis = (query: any, callback: any) => {
    if (query.length === 0) return;

    const matches = emojis
      .filter((emoji: any) => {
        return emoji.name.indexOf(query.toLowerCase()) > -1;
      })
      .slice(0, 10);
    return matches.map(({ emoji }) => ({ id: emoji }));
  };

  const fetchUsers = (query: any, callback: any): any => {
    if (!query) return;
    const f = setTimeout(() => {
      fetch(`https://api.github.com/search/users?q=${query}`)
        .then((res) => res.json())
        .then((res) =>
          res.items.map((user: any) => ({
            display: user.login,
            id: user.login,
          }))
        )
        .then(callback);
    }, 2000);
    return () => clearTimeout(f);
  };

  return (
    <>
      <AppCard>
        <Stack gap={0.8} className="new-post-section">
          <Stack className="post-content-section">
            <MentionsInput
              value={value}
              onChange={onChange}
              customSuggestionsContainer={(children: any) => {
                return (
                  <List
                    sx={{
                      width: "100%",
                      maxWidth: 360,
                      maxHeight: 400,
                      overflowY: "scroll",
                      bgcolor: "background.paper",
                    }}
                  >
                    {Array.from(children).map((c: any) => (
                      <ListItem
                        alignItems="flex-start"
                        onClick={c.props.onClick}
                      >
                        <ListItemAvatar>
                          <Avatar
                            alt="Cindy Baker"
                            src="/static/images/avatar/3.jpg"
                          />
                        </ListItemAvatar>
                        <ListItemText
                          primary="Oui Oui"
                          secondary={
                            <React.Fragment>
                              <Typography
                                sx={{ display: "inline" }}
                                component="span"
                                variant="body2"
                                color="text.primary"
                              >
                                {c.props?.suggestion?.display}
                              </Typography>
                              {
                                " — Do you have Paris recommendations? Have you ever…"
                              }
                            </React.Fragment>
                          }
                        />
                      </ListItem>
                    ))}
                  </List>
                );
              }}
              style={{
                control: {
                  backgroundColor: "#fff",
                  fontSize: 20,
                  fontWeight: "normal",
                },

                "&multiLine": {
                  control: {
                    minHeight: 200,
                    border: "none !important",
                  },
                  highlighter: {
                    padding: 9,
                    border: "1px solid transparent",
                  },
                  input: {
                    padding: 9,
                    border: "1px solid silver",
                    outlineStyle: "none",
                    boxShadow: "none",
                    borderColor: "gray",
                  },
                },

                suggestions: {
                  list: {
                    // backgroundColor: "white",
                    // border: "1px solid rgba(0,0,0,0.15)",
                    // fontSize: 40,
                    // maxHeight: "200px",
                    // overflowY: "scroll",
                  },
                  item: {
                    padding: "5px 15px",
                    borderBottom: "1px solid rgba(0,0,0,0.15)",
                    "&focused": {
                      backgroundColor: "#cee4e5",
                    },
                  },
                },
              }}
              placeholder={"Mention people using '@'"}
              a11ySuggestionsListLabel={"Suggested mentions"}
            >
              <Mention
                markup="@[__display__](user:__id__)"
                trigger="@"
                displayTransform={(login) => `@${login}`}
                data={fetchUsers}
                renderSuggestion={(
                  suggestion,
                  search,
                  highlightedDisplay,
                  index,
                  focused
                ) => (
                  <div className={`user ${focused ? "focused" : ""}`}>
                    {highlightedDisplay}
                  </div>
                )}
                onAdd={() => {}}
                style={{
                  backgroundColor: "#cee4e5",
                }}
              />

              <Mention
                markup="@[__display__](email:__id__)"
                trigger={emailRegex}
                data={(search) => [{ id: search, display: search }]}
                onAdd={() => {}}
                style={{ backgroundColor: "#d1c4e9" }}
              />

              <Mention
                trigger=":"
                markup="__id__"
                regex={/($a)/}
                data={queryEmojis}
              />
            </MentionsInput>
          </Stack>
          <Stack className="post-images-section">
            <Stack
              direction="row"
              alignItems="baseline"
              alignContent="center"
              justifyContent="flex-start"
              gap="0.4rem"
            >
              <AppImageUploader imagePickerState={setPostImages} />
              {!showPicker ? (
                <Tooltip sx={{ cursor: "pointer" }} title="Emoji">
                  <InsertEmoticonOutlinedIcon
                    color="action"
                    onClick={() => setShowEmojiPicker((old) => true)}
                  />
                </Tooltip>
              ) : (
                ""
              )}

              {showPicker ? (
                <CloseIcon
                  color="action"
                  onClick={() => setShowEmojiPicker((old) => !old)}
                />
              ) : (
                ""
              )}
              {showPicker ? (
                <EmojiPicker
                  onEmojiClick={(d) => {
                    return setValue((prev: any) => prev + d.emoji);
                  }}
                />
              ) : (
                ""
              )}
              {imagePreviewerState && (
                <AppImagePreviewer
                  previewState={imagePreviewerState}
                  show={imagePreviewerState}
                  handlePreview={setImagePreviewerState}
                  images={postImages}
                />
              )}
            </Stack>
          </Stack>
          <div
            style={{
              marginTop: "0.5rem",
              marginBottom: "0.5rem",
            }}
            className="post-image-preview-section"
          >
            {postImages?.length > 0 && (
              <Alert severity="info">
                {postImages.length} Images selected!
              </Alert>
            )}
          </div>
          <Stack>
            <AppImageList
              managePostImages={setPostImages}
              images={postImages}
            />
          </Stack>
          <Stack
            direction="row"
            alignItems="baseline"
            justifyContent="space-between"
            className="post-actions-sections"
          >
            <Stack className="post-view-selection-section">
              <Typography>Posting to {props?.currentView?.name}</Typography>
            </Stack>
            <Stack direction="row" justifyContent="flex-end" spacing={1}>
              <Button variant="outlined">Cancel</Button>
              <Button onClick={() => {}} variant="contained">
                Post
              </Button>
            </Stack>
          </Stack>
        </Stack>
      </AppCard>
    </>
  );
};

export default NewPost;
