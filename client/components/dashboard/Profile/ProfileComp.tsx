import Image from "next/image";
import profile from "../../../public/assets/images/profile.jpeg";
import marketplaceIcon from "../../../public/assets/icons/marketplaceIcon.svg";

const ProfileComp = () => {
  return (
    <main className="p-8 mb-28 xl:mb-0">
      <section>
        <div className="flex flex-col xl:w-[600px] w-[300] m-auto gap-4">
          <Image
            src={profile}
            alt="Profile picture"
            className="w-full h-[250px] object-cover object-left-top rounded-lg"
          />
          <div className="flex flex-col">
            <h1 className="text-[26px] font-semibold">Giorgi</h1>
            <h2 className="text-[16px] font-semibold">IASIKO</h2>
            <span>Joined June 2020</span>
            <div className="flex gap-4 text-[#1CB0F6] font-semibold">
              <span>0 Following</span>
              <span>0 Followers</span>
            </div>
            <div className="my-4 h-[2px] bg-slate-600"></div>
            <div>
              <h1 className="text-[26px] font-semibold">Statistics</h1>
            </div>
            <div className="grid grid-cols-2 gap-2">
              <div className="p-4 border border-[#1CB0F6] rounded-xl flex flex-col">
                <span className="font-bold text-[22px]">1</span>
                <span>Day streak</span>
              </div>
              <div className="p-4 border border-[#1CB0F6] rounded-xl flex flex-col">
                <span className="font-bold text-[22px]">1417</span>
                <span>Total XP</span>
              </div>
              <div className="p-4 border border-[#1CB0F6] rounded-xl flex flex-col">
                <span className="font-bold text-[22px]">Bronze</span>
                <span>Current league</span>
              </div>
              <div className="p-4 border border-[#1CB0F6] rounded-xl flex flex-col">
                <span className="font-bold text-[22px]">0</span>
                <span>Top 3 finishes</span>
              </div>
            </div>
            <div>
              <h1 className="text-[26px] font-semibold mt-4">Achievemnts</h1>
            </div>
            <Image src={marketplaceIcon} alt="NFT" className="w-20 h-20" />
          </div>
        </div>
      </section>
    </main>
  );
};

export default ProfileComp;
