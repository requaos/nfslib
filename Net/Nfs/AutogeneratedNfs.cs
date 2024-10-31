// InputSha 2B64687290672D3A7019B4337326D3FB42E37C6D
//
// This file was autogenerated using the BinaryFormatCodeGenerator
//     GenerationDateTime : 3/28/2018 1:25:52 PM
//
using System;
using System.Text;

using More;
using More.Core;
using More.Reflection;

namespace More.Net.Nfs
{
    public enum FileType {
        Regular = 1,
        Directory = 2,
        BlockDevice = 3,
        CharacterDevice = 4,
        SymbolicLink = 5,
        Socket = 6,
        NamedPipe = 7,
    }
    [Flags]
    public enum ModeFlags {
        OtherExecute = 1,
        OtherWrite = 2,
        OtherRead = 4,
        GroupExecute = 8,
        GroupWrite = 16,
        GroupRead = 32,
        OwnerExecute = 64,
        OwnerWrite = 128,
        OwnerRead = 256,
        SaveSwappedText = 512,
        SetGidOnExec = 1024,
        SetUidOnExec = 2048,
        UnknownFlag1 = 4096,
        UnknownFlag2 = 8192,
        UnknownFlag3 = 16384,
        UnknownFlag4 = 32768,
    }
}
namespace More.Net.Nfs3Procedure
{
        public enum Status {
            Ok = 0,
            ErrorPermission = 1,
            ErrorNoSuchFileOrDirectory = 2,
            ErrorIOHard = 5,
            ErrorIONoSuchDeviceOrAddress = 6,
            ErrorAccess = 13,
            ErrorAlreadyExists = 17,
            ErrorCrossLinkDevice = 18,
            ErrorNoSuchDevice = 19,
            ErrorNotDirectory = 20,
            ErrorIsDirectory = 21,
            ErrorInvalidArgument = 22,
            ErrorFileTooBig = 27,
            ErrorNoSpaceLeftOnDevice = 28,
            ErrorReadOnlyFileSystem = 30,
            ErrorToManyHardLinks = 31,
            ErrorNameTooLong = 63,
            ErrorDirectoryNotEmpty = 66,
            ErrorUserQuotaExceeded = 69,
            ErrorStaleFileHandle = 70,
            ErrorTooManyRemoteLevels = 71,
            ErrorBadHandle = 10001,
            ErrorNotSynchronized = 10002,
            ErrorBadCookie = 10003,
            ErrorNotSupported = 10004,
            ErrorTooSmall = 10005,
            ErrorServerFault = 10006,
            ErrorBadType = 10007,
            ErrorJukeBox = 10008,
        }
}
namespace More.Net.Nfs
{
    public struct Time
    {
        public const UInt32 FixedSerializationLength = 8;

        static InstanceSerializer serializer = null;
        public static InstanceSerializer Serializer
        {
            get
            {
                if(serializer == null) serializer = new InstanceSerializer();
                return serializer;
            }
        }

        public class InstanceSerializer : FixedLengthInstanceSerializer<Time>
        {
            public InstanceSerializer() {}
            public override UInt32 FixedSerializationLength() { return Time.FixedSerializationLength; }
            public override void FixedLengthSerialize(Byte[] bytes, UInt32 offset, Time instance)
            {
                bytes.BigEndianSetUInt32(offset, instance.seconds);
                offset += 4;
                bytes.BigEndianSetUInt32(offset, instance.nanoseconds);
                offset += 4;
            }
            public override Time FixedLengthDeserialize(Byte[] bytes, UInt32 offset)
            {
                return new Time (
                    bytes.BigEndianReadUInt32(offset + 0), // seconds
                    bytes.BigEndianReadUInt32(offset + 4) // nanoseconds
                );
            }
            public override void DataString(Time instance, StringBuilder builder)
            {
                builder.Append("Time:{");
                builder.Append(instance.seconds);
                builder.Append(',');
                builder.Append(instance.nanoseconds);
                builder.Append("}");
            }
            public override void DataSmallString(Time instance, StringBuilder builder)
            {
                builder.Append("Time:{");
                builder.Append(instance.seconds);
                builder.Append(',');
                builder.Append(instance.nanoseconds);
                builder.Append("}");
            }
        }

        public UInt32 seconds;
        public UInt32 nanoseconds;
        public Time(UInt32 seconds, UInt32 nanoseconds)
        {
            this.seconds = seconds;
            this.nanoseconds = nanoseconds;
        }
        public FixedLengthInstanceSerializerAdapter<Time> CreateSerializerAdapater()
        {
            return new FixedLengthInstanceSerializerAdapter<Time>(Serializer, this);
        }
    }
    public struct SizeAndTimes
    {
        public const UInt32 FixedSerializationLength = 24;

        static InstanceSerializer serializer = null;
        public static InstanceSerializer Serializer
        {
            get
            {
                if(serializer == null) serializer = new InstanceSerializer();
                return serializer;
            }
        }

        public class InstanceSerializer : FixedLengthInstanceSerializer<SizeAndTimes>
        {
            public InstanceSerializer() {}
            public override UInt32 FixedSerializationLength() { return SizeAndTimes.FixedSerializationLength; }
            public override void FixedLengthSerialize(Byte[] bytes, UInt32 offset, SizeAndTimes instance)
            {
                bytes.BigEndianSetUInt64(offset, instance.fileSize);
                offset += 8;
                Time.Serializer.Serialize(bytes, offset, instance.lastModifyTime);
                offset += 8;
                Time.Serializer.Serialize(bytes, offset, instance.lastAttributeModifyTime);
                offset += 8;
            }
            public override SizeAndTimes FixedLengthDeserialize(Byte[] bytes, UInt32 offset)
            {
                return new SizeAndTimes (
                    bytes.BigEndianReadUInt64(offset + 0), // fileSize
                    Time.Serializer.FixedLengthDeserialize(bytes, offset + 8), // lastModifyTime
                    Time.Serializer.FixedLengthDeserialize(bytes, offset + 16) // lastAttributeModifyTime
                );
            }
            public override void DataString(SizeAndTimes instance, StringBuilder builder)
            {
                builder.Append("SizeAndTimes:{");
                builder.Append(instance.fileSize);
                builder.Append(',');
                Time.Serializer.DataString(instance.lastModifyTime, builder);
                builder.Append(',');
                Time.Serializer.DataString(instance.lastAttributeModifyTime, builder);
                builder.Append("}");
            }
            public override void DataSmallString(SizeAndTimes instance, StringBuilder builder)
            {
                builder.Append("SizeAndTimes:{");
                builder.Append(instance.fileSize);
                builder.Append(',');
                Time.Serializer.DataSmallString(instance.lastModifyTime, builder);
                builder.Append(',');
                Time.Serializer.DataSmallString(instance.lastAttributeModifyTime, builder);
                builder.Append("}");
            }
        }

        public UInt64 fileSize;
        public Time lastModifyTime;
        public Time lastAttributeModifyTime;
        public SizeAndTimes(UInt64 fileSize, Time lastModifyTime, Time lastAttributeModifyTime)
        {
            this.fileSize = fileSize;
            this.lastModifyTime = lastModifyTime;
            this.lastAttributeModifyTime = lastAttributeModifyTime;
        }
        public FixedLengthInstanceSerializerAdapter<SizeAndTimes> CreateSerializerAdapater()
        {
            return new FixedLengthInstanceSerializerAdapter<SizeAndTimes>(Serializer, this);
        }
    }
    public struct FileAttributes
    {
        public const UInt32 FixedSerializationLength = 84;

        static InstanceSerializer serializer = null;
        public static InstanceSerializer Serializer
        {
            get
            {
                if(serializer == null) serializer = new InstanceSerializer();
                return serializer;
            }
        }

        public class InstanceSerializer : FixedLengthInstanceSerializer<FileAttributes>
        {
            public InstanceSerializer() {}
            public override UInt32 FixedSerializationLength() { return FileAttributes.FixedSerializationLength; }
            public override void FixedLengthSerialize(Byte[] bytes, UInt32 offset, FileAttributes instance)
            {
                BigEndianUnsignedEnumSerializer<FileType>.FourByteInstance.FixedLengthSerialize(bytes, offset, instance.fileType);
                offset += 4;
                BigEndianUnsignedEnumSerializer<ModeFlags>.FourByteInstance.FixedLengthSerialize(bytes, offset, instance.protectionMode);
                offset += 4;
                bytes.BigEndianSetUInt32(offset, instance.hardLinks);
                offset += 4;
                bytes.BigEndianSetUInt32(offset, instance.ownerUid);
                offset += 4;
                bytes.BigEndianSetUInt32(offset, instance.gid);
                offset += 4;
                bytes.BigEndianSetUInt64(offset, instance.fileSize);
                offset += 8;
                bytes.BigEndianSetUInt64(offset, instance.diskSize);
                offset += 8;
                bytes.BigEndianSetUInt32(offset, instance.specialData1);
                offset += 4;
                bytes.BigEndianSetUInt32(offset, instance.specialData2);
                offset += 4;
                bytes.BigEndianSetUInt64(offset, instance.fileSystemID);
                offset += 8;
                bytes.BigEndianSetUInt64(offset, instance.fileID);
                offset += 8;
                Time.Serializer.Serialize(bytes, offset, instance.lastAccessTime);
                offset += 8;
                Time.Serializer.Serialize(bytes, offset, instance.lastModifyTime);
                offset += 8;
                Time.Serializer.Serialize(bytes, offset, instance.lastAttributeModifyTime);
                offset += 8;
            }
            public override FileAttributes FixedLengthDeserialize(Byte[] bytes, UInt32 offset)
            {
                return new FileAttributes (
                    BigEndianUnsignedEnumSerializer<FileType>.FourByteInstance.FixedLengthDeserialize(bytes, offset + 0), // fileType
                    BigEndianUnsignedEnumSerializer<ModeFlags>.FourByteInstance.FixedLengthDeserialize(bytes, offset + 4), // protectionMode
                    bytes.BigEndianReadUInt32(offset + 8), // hardLinks
                    bytes.BigEndianReadUInt32(offset + 12), // ownerUid
                    bytes.BigEndianReadUInt32(offset + 16), // gid
                    bytes.BigEndianReadUInt64(offset + 20), // fileSize
                    bytes.BigEndianReadUInt64(offset + 28), // diskSize
                    bytes.BigEndianReadUInt32(offset + 36), // specialData1
                    bytes.BigEndianReadUInt32(offset + 40), // specialData2
                    bytes.BigEndianReadUInt64(offset + 44), // fileSystemID
                    bytes.BigEndianReadUInt64(offset + 52), // fileID
                    Time.Serializer.FixedLengthDeserialize(bytes, offset + 60), // lastAccessTime
                    Time.Serializer.FixedLengthDeserialize(bytes, offset + 68), // lastModifyTime
                    Time.Serializer.FixedLengthDeserialize(bytes, offset + 76) // lastAttributeModifyTime
                );
            }
            public override void DataString(FileAttributes instance, StringBuilder builder)
            {
                builder.Append("FileAttributes:{");
                builder.Append(instance.fileType);
                builder.Append(',');
                builder.Append(instance.protectionMode);
                builder.Append(',');
                builder.Append(instance.hardLinks);
                builder.Append(',');
                builder.Append(instance.ownerUid);
                builder.Append(',');
                builder.Append(instance.gid);
                builder.Append(',');
                builder.Append(instance.fileSize);
                builder.Append(',');
                builder.Append(instance.diskSize);
                builder.Append(',');
                builder.Append(instance.specialData1);
                builder.Append(',');
                builder.Append(instance.specialData2);
                builder.Append(',');
                builder.Append(instance.fileSystemID);
                builder.Append(',');
                builder.Append(instance.fileID);
                builder.Append(',');
                Time.Serializer.DataString(instance.lastAccessTime, builder);
                builder.Append(',');
                Time.Serializer.DataString(instance.lastModifyTime, builder);
                builder.Append(',');
                Time.Serializer.DataString(instance.lastAttributeModifyTime, builder);
                builder.Append("}");
            }
            public override void DataSmallString(FileAttributes instance, StringBuilder builder)
            {
                builder.Append("FileAttributes:{");
                builder.Append(instance.fileType);
                builder.Append(',');
                builder.Append(instance.protectionMode);
                builder.Append(',');
                builder.Append(instance.hardLinks);
                builder.Append(',');
                builder.Append(instance.ownerUid);
                builder.Append(',');
                builder.Append(instance.gid);
                builder.Append(',');
                builder.Append(instance.fileSize);
                builder.Append(',');
                builder.Append(instance.diskSize);
                builder.Append(',');
                builder.Append(instance.specialData1);
                builder.Append(',');
                builder.Append(instance.specialData2);
                builder.Append(',');
                builder.Append(instance.fileSystemID);
                builder.Append(',');
                builder.Append(instance.fileID);
                builder.Append(',');
                Time.Serializer.DataSmallString(instance.lastAccessTime, builder);
                builder.Append(',');
                Time.Serializer.DataSmallString(instance.lastModifyTime, builder);
                builder.Append(',');
                Time.Serializer.DataSmallString(instance.lastAttributeModifyTime, builder);
                builder.Append("}");
            }
        }

        public FileType fileType;
        public ModeFlags protectionMode;
        public UInt32 hardLinks;
        public UInt32 ownerUid;
        public UInt32 gid;
        public UInt64 fileSize;
        public UInt64 diskSize;
        public UInt32 specialData1;
        public UInt32 specialData2;
        public UInt64 fileSystemID;
        public UInt64 fileID;
        public Time lastAccessTime;
        public Time lastModifyTime;
        public Time lastAttributeModifyTime;
        public FileAttributes(FileType fileType, ModeFlags protectionMode, UInt32 hardLinks, UInt32 ownerUid, UInt32 gid, UInt64 fileSize, UInt64 diskSize, UInt32 specialData1, UInt32 specialData2, UInt64 fileSystemID, UInt64 fileID, Time lastAccessTime, Time lastModifyTime, Time lastAttributeModifyTime)
        {
            this.fileType = fileType;
            this.protectionMode = protectionMode;
            this.hardLinks = hardLinks;
            this.ownerUid = ownerUid;
            this.gid = gid;
            this.fileSize = fileSize;
            this.diskSize = diskSize;
            this.specialData1 = specialData1;
            this.specialData2 = specialData2;
            this.fileSystemID = fileSystemID;
            this.fileID = fileID;
            this.lastAccessTime = lastAccessTime;
            this.lastModifyTime = lastModifyTime;
            this.lastAttributeModifyTime = lastAttributeModifyTime;
        }
        public FixedLengthInstanceSerializerAdapter<FileAttributes> CreateSerializerAdapater()
        {
            return new FixedLengthInstanceSerializerAdapter<FileAttributes>(Serializer, this);
        }
    }
}