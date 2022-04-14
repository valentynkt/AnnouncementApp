import React from "react";
import { MainLayout } from "../Components/MainLayout";
import { NavLink, useNavigate, useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axios from "axios";
import { Button, CircularProgress } from "@mui/material";
export const Details = () => {
  const { id } = useParams();
  const [announcement, setAnnouncements] = useState(null);
  const navigate = useNavigate();
  const editFunc = (id) => {
    let path = `/${id}/edit`;
    navigate(path);
  };
  const deleteFunc = (id) => {
    let path = `/${id}/delete`;
    navigate(path);
  };
  const detailsFunc = (id) => {
    let path = `/${id}`;
    navigate(path);
  };
  useEffect(() => {
    axios
      .get(`announcement/${id}`)
      .then((res) => setAnnouncements(res.data))
      .catch((err) => console.log(err));
  }, [id]);
  if (announcement) {
    console.log(announcement);
    return (
      <MainLayout>
        <div className="details">
          <h2 className="announcementTitle">{announcement.title}</h2>
          <p className="announcementDescriptiom">{announcement.description}</p>
          <div className="buttons">
            <Button
              variant="contained"
              onClick={() => editFunc(announcement.id)}
            >
              Edit
            </Button>
            <Button
              variant="contained"
              color="error"
              onClick={() => deleteFunc(announcement.id)}
            >
              Delete
            </Button>
          </div>
          {announcement.similarAnnouncement.map((x)=>(
            <>
             <div className="announcementTitle" onClick={() => detailsFunc(x.id)}>{x.title}</div>
            </>
          ))}
        </div>
      </MainLayout>
    );
  } else
    return (
      <div>
        <CircularProgress size={120} />
      </div>
    );
};
