import React, { useState, useEffect } from "react";
import { apiClient } from "./ApiClient";
import { UpdateLead } from "./UpdateLead";

export function ListInvitedJobs() {
    const [jobs, setJobs] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchJobs = async () => {
            try {
                const response = await apiClient('Job?leadStatus=1');
                setJobs(response.data);
            } catch (error) {
                console.error("Erro ao buscar as vagas!", error);
            } finally {
                setLoading(false);
            }
        };

        fetchJobs();
    }, [jobs]);

    if (loading) {
        return <div className="centralizada">Carregando...</div>;
    } else {
        return (
            <div className="p-4 bg-white shadow rounded-lg">
                {jobs.map((job, index) => (
                    <div key={index} className="p-4 border-b border-neutral-300 flex flex-col gap-2 grow">
                        <div className="flex justify-between items-center">
                            <h3 className="text-neutral-900 font-semibold">
                                {job.lead.contactFirstName}
                            </h3>
                            <p className="text-neutral-600 text-sm">{job.jobDate}</p>
                        </div>

                        <div className="flex items-center text-neutral-600 gap-4 mt-2">
                            <span className="material-symbols-outlined text-sm">location_on</span>
                            <p className="text-sm">{job.lead.suburb}</p>
                            <p className="text-sm">{job.jobCategory}</p>
                            <p className="text-sm">Job ID: {job.jobID}</p>
                            <p className="text-neutral-700 text-sm mt-2">Description:{job.jobDescription}</p>
                        </div>


                        <div className="flex justify-between items-center mt-4">
                            <div className="flex gap-4">
                                <button
                                    onClick={() => UpdateLead({ leadId: job.jobID, statusLead: 2 })}
                                    className="border-orange-500 button-accepted rounded-lg px-4 py-2 font-semibold shadow"
                                >
                                    Aceitar
                                </button>
                                <button
                                    onClick={() => UpdateLead({ leadId: job.jobID, statusLead: 3 })}
                                    className="border-orange-500 button-declined rounded-lg px-4 py-2 font-semibold shadow"
                                >
                                    Recusar
                                </button>
                            </div>
                            <p className="text-neutral-600 text-sm"> {job.jobPrice}$ - Convite de Trabalho
                            </p>
                        </div>
                    </div>
                ))}
            </div>
        );
    }
}