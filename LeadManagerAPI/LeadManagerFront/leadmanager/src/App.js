import React, { useState } from "react";
import { ListAcceptedJobs } from './ListAcceptedJobs';
import { ListInvitedJobs } from './ListInvitedJobs';

export function App() {
  const [activeList, setActiveList] = useState("invited");
  const [invitedDivVisibility, setInvitedDivVisibility] = useState("visible");
  const [acceptedDivVisibility, setAcceptedDivVisibility] = useState("hidden");

  const handleTabClick = (status) => {
    setActiveList(status);

    if (status === "invited") {
      setInvitedDivVisibility("visible");
      setAcceptedDivVisibility("hidden");
    }
    else {
      setInvitedDivVisibility("hidden");
      setAcceptedDivVisibility("visible");
    }
  };

  return (
    <div id="webcrumbs" className="centralizada">
      <div className="w-[600px] shadow rounded-lg bg-white">
        <div className="flex border-b border-neutral-300">
          <button onClick={() => handleTabClick("invited")} className={`basis-1/2 py-3 text-center border-b-4 text-neutral-600 ${invitedDivVisibility === "visible" && "border-orange-500 font-semibold"}`}>
            Invited
          </button>
          <button onClick={() => handleTabClick("accepted")} className={`basis-1/2 py-3 text-center border-b-4 text-neutral-600 ${acceptedDivVisibility === "visible" && "border-orange-500 font-semibold"}`}>
            Accepted
          </button>
        </div>
        <div style={{visibility: invitedDivVisibility}} className="p-4 flex gap-4 border-b border-neutral-300">
          {activeList === "invited" && <ListInvitedJobs />}
        </div>
        <div style={{visibility: acceptedDivVisibility}} className="p-4 flex gap-4 border-b border-neutral-300">
          {activeList === "accepted" && <ListAcceptedJobs />}
        </div>
      </div>
    </div>
  );
}
